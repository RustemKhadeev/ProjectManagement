using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Server.Models.Bases.ActionResults;
using ProjectManagement.Server.Models.Models.Employees.Interfaces;
using ProjectManagement.Shared.Models.Models.Employees;

namespace ProjectManagement.Server.Controllers
{
    [Route("[controller]")]
    public class CatalogEmployeeController : ControllerBase
    {
        private readonly IRepositoryCatalogEmployee _repositoryCatalogEmployee;

        public CatalogEmployeeController(IRepositoryCatalogEmployee repositoryCatalogEmployee)
        {
            _repositoryCatalogEmployee = repositoryCatalogEmployee;
        }

        [HttpGet("GetCatalog")]
        public async Task<BaseResponseActionResult<List<CatalogEmployeeJournalItemDto>>> GetCatalog()
        {
            var ret = await _repositoryCatalogEmployee.GetAllDtoAsync();
            return ret;
        }

        [HttpGet("GetList")]
        public async Task<BaseResponseActionResult<List<CatalogEmployeeComboboxDto>>> GetList()
        {
            var ret = await _repositoryCatalogEmployee.GetListAsync();
            return ret;
        }

        [HttpPost("Create")]
        public async Task<BaseResponseActionResult<CatalogEmployeeDto>> Create()
        {
            var ret = await _repositoryCatalogEmployee.CreateAndMapToDto();
            return ret;
        }

        [HttpGet("{id}")]
        public async Task<BaseResponseActionResult<CatalogEmployeeDto>> GetCatalogEmployee(int id)
        {
            var employee = await _repositoryCatalogEmployee.GetByIdAsync(id);
            if (employee == null)
                return new BaseNotFound();

            var ret = await _repositoryCatalogEmployee.GetDtoByIdAsync(id);
            return ret;
        }

        [HttpPut("{id}")]
        public async Task<BaseResponseActionResult<CatalogEmployeeDto>> PutCatalogEmployee(int id, [FromBody] CatalogEmployeeDto employeeDto)
        {
            if (id != employeeDto.Id)
                return new BaseBadRequest();

            var employee = await _repositoryCatalogEmployee.GetByIdAsync(id);
            if (employee == null)
                return new BaseNotFound();

            var ret = await _repositoryCatalogEmployee.SaveDtoAsync(employeeDto);
            return ret;
        }

        [HttpDelete("{id}")]
        public async Task<BaseResponseActionResult<bool>> DeleteCatalogEmployee(int id)
        {
            var division = await _repositoryCatalogEmployee.GetByIdAsync(id);
            if (division == null)
                return new BaseNotFound();

            await _repositoryCatalogEmployee.DeleteAsync(division);
            return new BaseNoContent();
        }
    }
}
