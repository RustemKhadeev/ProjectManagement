using ProjectManagement.Client.Models.Bases;
using ProjectManagement.Shared.Models.Bases;
using ProjectManagement.Shared.Models.Models.Employees;

namespace ProjectManagement.Client.Models.Services
{
    public class CatalogEmployeeService : BaseCatalogService<CatalogEmployeeComboboxDto>
    {
        public CatalogEmployeeService(IHttpClientFactory clientFactory)
            : base(clientFactory)
        {
        }

        public async Task<BaseResponse<List<CatalogEmployeeJournalItemDto>>> GetCatalogEmployeeAsync()
        {
            var res = await SendAsync<List<CatalogEmployeeJournalItemDto>>("GetCatalog", HttpMethod.Get);
            return res;
        }

        public async Task<BaseResponse<CatalogEmployeeDto>> CreateAsync()
        {
            var res = await SendAsync<CatalogEmployeeDto>("Create", HttpMethod.Post);
            return res;
        }

        public async Task<BaseResponse<CatalogEmployeeDto>> GetAsync(int id)
        {
            var dto = await SendAsync<CatalogEmployeeDto>($"{id}", HttpMethod.Get);
            return dto;
        }

        public async Task PutAsync(CatalogEmployeeDto employee)
        {
            await SendAsync<CatalogEmployeeDto>($"{employee.Id}", HttpMethod.Put, employee);
        }

        public async Task<BaseResponse<object>> DeleteAsync(CatalogEmployeeJournalItemDto employeeJournalItem)
        {
            return await SendAsync<object>($"{employeeJournalItem.Id}", HttpMethod.Delete);
        }

        protected override string BasePath => "CatalogEmployee";
    }
}
