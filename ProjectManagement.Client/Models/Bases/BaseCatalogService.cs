using ProjectManagement.Shared.Models.Bases;

namespace ProjectManagement.Client.Models.Bases
{
    public class BaseCatalogService<TComboboxDto> : BaseService
    where TComboboxDto : class
    {
        public BaseCatalogService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
        }

        public virtual async Task<BaseResponse<List<TComboboxDto>>> GetListAsync(string query = "")
        {
            var res = await SendAsync<List<TComboboxDto>>("GetList", HttpMethod.Get);
            return res;
        }

        protected override string BasePath { get; }
    }
}
