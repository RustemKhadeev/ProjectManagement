using ProjectManagement.Client.Models.Bases;
using ProjectManagement.Shared.Models.Bases;
using ProjectManagement.Shared.Models.Models.ProjectTasks;

namespace ProjectManagement.Client.Models.Services
{
    public class CatalogProjectTaskService : BaseCatalogService<CatalogProjectTaskComboboxDto>
    {
        public CatalogProjectTaskService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
        }

        public async Task<BaseResponse<List<CatalogProjectTaskJournalItemDto>>> GetCatalogProjectTaskAsync()
        {
            var res = await SendAsync<List<CatalogProjectTaskJournalItemDto>>("GetCatalog", HttpMethod.Get);
            return res;
        }

        public async Task<BaseResponse<CatalogProjectTaskDto>> CreateAsync()
        {
            var res = await SendAsync<CatalogProjectTaskDto>("Create", HttpMethod.Post);
            return res;
        }

        public async Task<BaseResponse<CatalogProjectTaskDto>> GetAsync(int id)
        {
            var dto = await SendAsync<CatalogProjectTaskDto>($"{id}", HttpMethod.Get);
            return dto;
        }

        public async Task<BaseResponse<CatalogProjectTaskDto>> PutAsync(CatalogProjectTaskDto projectTask)
        {
            return await SendAsync<CatalogProjectTaskDto>($"{projectTask.Id}", HttpMethod.Put, projectTask);
        }

        public async Task<BaseResponse<object>> DeleteAsync(CatalogProjectTaskJournalItemDto projectTaskJournalItem)
        {
            return await SendAsync<object>($"{projectTaskJournalItem.Id}", HttpMethod.Delete);
        }

        public async Task<BaseResponse<CatalogProjectTaskDto>> AddTaskInProject(
            CatalogProjectTaskDto projectTask)
        {
            return await SendAsync<CatalogProjectTaskDto>($"AddTaskInProject", HttpMethod.Post, projectTask);
        }

        public async Task<BaseResponse<CatalogProjectTaskDto>> RemoveTaskFromProject(
            CatalogProjectTaskJournalItemDto projectTaskJournalItem)
        {
            return await SendAsync<CatalogProjectTaskDto>($"RemoveTaskFromProject/{projectTaskJournalItem.Id}", HttpMethod.Post);
        }

        protected override string BasePath => "CatalogProjectTask";
    }
}
