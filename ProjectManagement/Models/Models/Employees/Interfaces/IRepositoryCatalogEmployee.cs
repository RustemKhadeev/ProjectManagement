using ProjectManagement.Server.Models.Bases.Interfaces.IBases;
using ProjectManagement.Server.Models.Models.Employees.Domain;
using ProjectManagement.Shared.Models.Models.Employees;

namespace ProjectManagement.Server.Models.Models.Employees.Interfaces;

public interface IRepositoryCatalogEmployee 
    : IBaseRepositoryHaveJournal<CatalogEmployee, CatalogEmployeeDto, CatalogEmployeeJournalItemDto>
{
    Task<List<CatalogEmployeeComboboxDto>> GetListAsync();
}