using ProjectManagement.Client.Models.Bases;
using ProjectManagement.Shared.Models.Bases;
using ProjectManagement.Shared.Models.Models.Projects;

namespace ProjectManagement.Client.Models.Services
{
    public class CatalogProjectService : BaseCatalogService<CatalogProjectComboboxDto>
    {
        public CatalogProjectService(IHttpClientFactory clientFactory)
            : base(clientFactory)
        {
        }

        public async Task<BaseResponse<List<CatalogProjectJournalItemDto>>> GetCatalogProjectAsync()
        {
            var res = await SendAsync<List<CatalogProjectJournalItemDto>>("GetCatalog", HttpMethod.Get);
            return res;
        }

        public async Task<BaseResponse<CatalogProjectDto>> CreateAsync()
        {
            var res = await SendAsync<CatalogProjectDto>("Create", HttpMethod.Post);
            return res;
        }

        public async Task<BaseResponse<CatalogProjectDto>> GetAsync(int id)
        {
            var dto = await SendAsync<CatalogProjectDto>($"{id}", HttpMethod.Get);
            return dto;
        }

        public async Task PutAsync(CatalogProjectDto project)
        {
            await SendAsync<CatalogProjectDto>($"{project.Id}", HttpMethod.Put, project);
        }

        public async Task<BaseResponse<object>> DeleteAsync(CatalogProjectJournalItemDto projectJournalItem)
        {
            return await SendAsync<object>($"{projectJournalItem.Id}", HttpMethod.Delete);
        }

        protected override string BasePath => "CatalogProject";
    }
}
