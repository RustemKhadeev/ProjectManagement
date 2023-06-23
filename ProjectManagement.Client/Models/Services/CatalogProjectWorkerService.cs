using ProjectManagement.Client.Models.Bases;
using ProjectManagement.Shared.Models.Bases;
using ProjectManagement.Shared.Models.Models.ProjectWorkers;

namespace ProjectManagement.Client.Models.Services
{
    public class CatalogProjectWorkerService : BaseService
    {
        public CatalogProjectWorkerService(IHttpClientFactory clientFactory) 
            : base(clientFactory)
        {
        }

        public async Task<BaseResponse<List<CatalogProjectWorkerJournalItemDto>>> GetProjectWorkerListAsync()
        {
            var res = await SendAsync<List<CatalogProjectWorkerJournalItemDto>>("GetList", HttpMethod.Get);
            return res;
        }

        public async Task<BaseResponse<CatalogProjectWorkerDto>> CreateAsync()
        {
            var res = await SendAsync<CatalogProjectWorkerDto>("Create", HttpMethod.Post);
            return res;
        }

        public async Task<BaseResponse<CatalogProjectWorkerDto>> GetAsync(int id)
        {
            var dto = await SendAsync<CatalogProjectWorkerDto>($"{id}", HttpMethod.Get);
            return dto;
        }

        public async Task<BaseResponse<CatalogProjectWorkerDto>> PutAsync(CatalogProjectWorkerDto project)
        {
            var ret = await SendAsync<CatalogProjectWorkerDto>($"{project.Id}", HttpMethod.Put, project);
            return ret;
        }

        public async Task<BaseResponse<object>> DeleteAsync(CatalogProjectWorkerJournalItemDto projectEmployeeJournalItem)
        {
            return await SendAsync<object>($"{projectEmployeeJournalItem.Id}", HttpMethod.Delete);
        }

        protected override string BasePath => "CatalogProjectWorker";
    }
}
