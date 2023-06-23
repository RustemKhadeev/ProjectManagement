using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using ProjectManagement.Client.Models.Bases;
using ProjectManagement.Shared.Models.Interfaces;

namespace ProjectManagement.Client.Components.Editors
{
    public class BaseMultipleSelect<TValue, TItem, TService> : ComponentBase, IDisposable where TItem : class
    {
        private Timer _debounceTimer;
        private IEnumerable<TValue> _value;
        protected bool IsLoading;
        protected string Search = "";
        protected IEnumerable<int?> CurrentValue { get; set; }
        protected bool DebounceEnabled => DebounceMilliseconds != 0;
        protected List<int?> SelectList { get; set; } = new();
        protected List<TItem> List { get; set; } = new();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void OnSelectedItemsChanged(IEnumerable<TItem> values)
        {
            _ = OnValuesChangeAsync(values);
        }

        protected async Task OnValuesChangeAsync(IEnumerable<TItem> values)
        {
            var list = new List<TValue>();

            if (values != null) list.AddRange(values.Select(item => (TValue)(object)item));

            await ValueChanged.InvokeAsync(list);

            if (OnChange.HasDelegate)
                await OnChange.InvokeAsync();
        }

        public IEnumerable<int?> FormatValue(IEnumerable<TValue> values)
        {
            if (values == null)
                return new List<int?>().AsEnumerable();

            var currentValue = new List<TItem>();
            var d = JsonConvert.DeserializeObject<List<TItem>>(JsonConvert.SerializeObject(values));
            if (d != null)
                currentValue.AddRange(d);

            var valuesAsInt = new List<int?>();
            foreach (var item in currentValue)
            {
                var nulable = (item as IHaveIdNulable)?.Id;
                if (nulable != null)
                    valuesAsInt.Add(nulable);
                if (item is IHaveId id)
                    valuesAsInt.Add(id.Id);
            }

            return valuesAsInt.AsEnumerable();
        }

        public IEnumerable<TItem> FormatValueAsItem(IEnumerable<TValue> values)
        {
            if (values == null)
                return new List<TItem>().AsEnumerable();

            var currentValue = new List<TItem>();
            var d = JsonConvert.DeserializeObject<List<TItem>>(JsonConvert.SerializeObject(values));
            if (d != null)
                currentValue.AddRange(d);

            return currentValue.AsEnumerable();
        }

        protected virtual async Task<List<TItem>> GetDataAsync(string query = "")
        {
            IsLoading = true;
            StateHasChanged();

            var result = (await ((BaseCatalogService<TItem>)(object)Service).GetListAsync(query)).Result;
            var list = JsonConvert.DeserializeObject<List<TItem>>(result.ToString());

            IsLoading = false;
            return list;
        }

        protected void DebounceChangeSearch(string value)
        {
            _debounceTimer?.Dispose();
            _debounceTimer = new Timer(DebounceTimerIntervalOnTick, value, DebounceMilliseconds, DebounceMilliseconds);
        }

        protected void DebounceTimerIntervalOnTick(object state)
        {
            InvokeAsync(async () => await ChangeSearch((string)state, true));
        }

        private async Task ChangeSearch(string value, bool ignoreDebounce = false)
        {
            if (DebounceEnabled)
            {
                if (!ignoreDebounce)
                {
                    DebounceChangeSearch(value);
                    return;
                }

                _debounceTimer?.Dispose();
                if (_debounceTimer != null)
                    _debounceTimer = null;
            }

            Search = value;

            var list = await GetDataAsync(value);
            list.RemoveAll(r => SelectList.Any(a => a == ((IHaveIdNulable)r).Id));
            list.RemoveAll(r => List.Any(a => ((IHaveIdNulable)a).Id == ((IHaveIdNulable)r).Id));
            List.AddRange(list);

            StateHasChanged();
        }

        protected void OnSearch(string value)
        {
            InvokeAsync(async () => await ChangeSearch(value));
        }

        protected void OnBlur()
        {
            InvokeAsync(async () =>
            {
                await Task.Delay(200);
                Search = "";
            });
        }
        
        protected void OnFocus()
        {
            InvokeAsync(async () => await ChangeSearch(Search, true));
            StateHasChanged();
        }

        protected override void OnInitialized()
        {
            if (Value != null)
            {
                SelectList = FormatValue(Value).ToList();
                List = FormatValueAsItem(Value).ToList();
                CurrentValue = SelectList;
            }

            base.OnInitialized();
        }

        protected override Task OnInitializedAsync()
        {
            return Task.CompletedTask;
        }

        protected virtual void Dispose(bool disposing)
        {
        }

        #region Parameters

        [Parameter] 
        public int DebounceMilliseconds { get; set; } = 600;

        [Parameter]
        public IEnumerable<TValue> Value
        {
            get => _value;
            set
            {
                _value = value;
                CurrentValue = FormatValue(_value);
            }
        }

        [Parameter] 
        public EventCallback<IEnumerable<TValue>> ValueChanged { get; set; }

        [Parameter] 
        public EventCallback OnChange { get; set; }

        [Parameter] 
        public string Placeholder { get; set; } = "";

        [Parameter]
        public bool IsEditable { get; set; } = true;

        [Inject] 
        protected TService Service { get; set; }

        #endregion
    }
}
