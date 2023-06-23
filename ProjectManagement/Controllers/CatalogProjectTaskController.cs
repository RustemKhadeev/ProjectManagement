using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Server.Models.Bases.ActionResults;
using ProjectManagement.Server.Models.Models.ProjectTasks.Domain;
using ProjectManagement.Server.Models.Models.ProjectTasks.Interfaces;
using ProjectManagement.Shared.Models.Models.ProjectTasks;

namespace ProjectManagement.Server.Controllers
{
    [Route("[controller]")]
    public class CatalogProjectTaskController : ControllerBase
    {
        private readonly IRepositoryCatalogProjectTask _repositoryCatalogProjectTasks;

        public CatalogProjectTaskController(IRepositoryCatalogProjectTask repositoryCatalogProjectTask)
        {
            _repositoryCatalogProjectTasks = repositoryCatalogProjectTask;
        }

        [HttpGet("GetCatalog")]
        public async Task<BaseResponseActionResult<List<CatalogProjectTaskJournalItemDto>>> GetCatalog()
        {
            var ret = await _repositoryCatalogProjectTasks.GetAllDtoAsync();
            return ret;
        }

        [HttpGet("GetList")]
        public async Task<BaseResponseActionResult<List<CatalogProjectTaskComboboxDto>>> GetList()
        {
            var ret = await _repositoryCatalogProjectTasks.GetListAsync();
            return ret;
        }

        [HttpPost("Create")]
        public async Task<BaseResponseActionResult<CatalogProjectTaskDto>> Create()
        {
            var ret = await _repositoryCatalogProjectTasks.CreateAndMapToDto();
            return ret;
        }

        [HttpGet("{id}")]
        public async Task<BaseResponseActionResult<CatalogProjectTaskDto>> GetCatalogProject(int id)
        {
            var project = await _repositoryCatalogProjectTasks.GetByIdAsync(id);
            if (project == null)
                return new BaseNotFound();

            var ret = await _repositoryCatalogProjectTasks.GetDtoByIdAsync(id);
            return ret;
        }

        [HttpPut("{id}")]
        public async Task<BaseResponseActionResult<CatalogProjectTaskDto>> PutCatalogProject(int id, [FromBody] CatalogProjectTaskDto projectDto)
        {
            if (id != projectDto.Id)
                return new BaseBadRequest();

            var project = await _repositoryCatalogProjectTasks.GetByIdAsync(id);
            if (project == null)
                return new BaseNotFound();

            var ret = await _repositoryCatalogProjectTasks.SaveDtoAsync(projectDto);
            return ret;
        }

        [HttpDelete("{id}")]
        public async Task<BaseResponseActionResult<bool>> DeleteCatalogProject(int id)
        {
            var project = await _repositoryCatalogProjectTasks.GetByIdAsync(id);
            if (project == null)
                return new BaseNotFound();

            await _repositoryCatalogProjectTasks.DeleteAsync(project);

            return new BaseNoContent();
        }

        [HttpPost("RemoveTaskFromProject/{Id}")]
        public async Task<CatalogProjectTask> RemoveTaskFromProject(int id)
        {
            return await _repositoryCatalogProjectTasks.RemoveTaskFromProject(id);
        }

        [HttpPost("AddTaskInProject")]
        public async Task<CatalogProjectTask> AddTaskInProject([FromBody] CatalogProjectTaskDto projectTask)
        {
            return await _repositoryCatalogProjectTasks.AddTaskInProject(projectTask);
        }
    }
}
