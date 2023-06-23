using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Server.Models.Bases.ActionResults;
using ProjectManagement.Server.Models.Models.Projects.Interfaces;
using ProjectManagement.Shared.Models.Models.Projects;

namespace ProjectManagement.Server.Controllers
{
    [Route("[controller]")]
    public class CatalogProjectController : ControllerBase
    {
        private readonly IRepositoryCatalogProject _repositoryCatalogProject;

        public CatalogProjectController(IRepositoryCatalogProject repositoryCatalogProject)
        {
            _repositoryCatalogProject = repositoryCatalogProject;
        }

        [HttpGet("GetCatalog")]
        public async Task<BaseResponseActionResult<List<CatalogProjectJournalItemDto>>> GetCatalog()
        {
            var ret = await _repositoryCatalogProject.GetAllDtoAsync();
            return ret;
        }

        [HttpGet("GetList")]
        public async Task<BaseResponseActionResult<List<CatalogProjectComboboxDto>>> GetList()
        {
            var ret = await _repositoryCatalogProject.GetListAsync();
            return ret;
        }

        [HttpPost("Create")]
        public async Task<BaseResponseActionResult<CatalogProjectDto>> Create()
        {
            var ret = await _repositoryCatalogProject.CreateAndMapToDto();
            return ret;
        }

        [HttpGet("{id}")]
        public async Task<BaseResponseActionResult<CatalogProjectDto>> GetCatalogProject(int id)
        {
            var project = await _repositoryCatalogProject.GetByIdAsync(id);
            if (project == null)
                return new BaseNotFound();

            var ret = await _repositoryCatalogProject.GetDtoByIdAsync(id);
            return ret;
        }

        [HttpPut("{id}")]
        public async Task<BaseResponseActionResult<CatalogProjectDto>> PutCatalogProject(int id, [FromBody] CatalogProjectDto projectDto)
        {
            if (id != projectDto.Id)
                return new BaseBadRequest();

            var project = await _repositoryCatalogProject.GetByIdAsync(id);
            if (project == null)
                return new BaseNotFound();

            var ret = await _repositoryCatalogProject.SaveDtoAsync(projectDto);
            return ret;
        }

        [HttpDelete("{id}")]
        public async Task<BaseResponseActionResult<bool>> DeleteCatalogProject(int id)
        {
            var project = await _repositoryCatalogProject.GetByIdAsync(id);
            if (project == null)
                return new BaseNotFound();

            await _repositoryCatalogProject.DeleteAsync(project);

            return new BaseNoContent();
        }
    }
}
