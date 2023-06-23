using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Server.Models.Bases.ActionResults;
using ProjectManagement.Server.Models.Models.ProjectWorkers.Interfaces;
using ProjectManagement.Shared.Models.Models.ProjectWorkers;

namespace ProjectManagement.Server.Controllers
{
    [Route("[controller]")]
    public class CatalogProjectWorkerController : ControllerBase
    {
        private readonly IRepositoryCatalogProjectWorker _repositoryCatalogProjectWorker;

        public CatalogProjectWorkerController(IRepositoryCatalogProjectWorker repositoryCatalogProjectWorker)
        {
            _repositoryCatalogProjectWorker = repositoryCatalogProjectWorker;
        }

        [HttpGet("GetList")]
        public async Task<BaseResponseActionResult<List<CatalogProjectWorkerJournalItemDto>>> GetList()
        {
            var ret = await _repositoryCatalogProjectWorker.GetAllDtoAsync();
            return ret;
        }

        [HttpPost("Create")]
        public async Task<BaseResponseActionResult<CatalogProjectWorkerDto>> Create()
        {
            var ret = await _repositoryCatalogProjectWorker.CreateAndMapToDto();
            return ret;
        }

        [HttpGet("{id}")]
        public async Task<BaseResponseActionResult<CatalogProjectWorkerDto>> GetCatalogProjectWorker(int id)
        {
            var project = await _repositoryCatalogProjectWorker.GetByIdAsync(id);
            if (project == null)
                return new BaseNotFound();

            var ret = await _repositoryCatalogProjectWorker.GetDtoByIdAsync(id);
            return ret;
        }

        [HttpPut("{id}")]
        public async Task<BaseResponseActionResult<CatalogProjectWorkerDto>> PutCatalogProjectWorker(int id, [FromBody] CatalogProjectWorkerDto projectDto)
        {
            if (id != projectDto.Id)
                return new BaseBadRequest();

            var ret = await _repositoryCatalogProjectWorker.SaveDtoAsync(projectDto);
            return ret;
        }

        [HttpDelete("{id}")]
        public async Task<BaseResponseActionResult<bool>> DeleteCatalogProjectWorker(int id)
        {
            var project = await _repositoryCatalogProjectWorker.GetByIdAsync(id);
            if (project == null)
                return new BaseNotFound();

            await _repositoryCatalogProjectWorker.DeleteAsync(project);
            return new BaseNoContent();
        }
    }
}
