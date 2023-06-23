using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Server.Models.Bases.Repositories;
using ProjectManagement.Server.Models.Contexts;
using ProjectManagement.Server.Models.Models.Employees.Domain;
using ProjectManagement.Server.Models.Models.Employees.Interfaces;
using ProjectManagement.Shared.Models.Models.Employees;

namespace ProjectManagement.Server.Models.Models.Employees.Repositories;

public class RepositoryCatalogEmployee
    : BaseRepositoryHaveJournal<CatalogEmployee, CatalogEmployeeDto, CatalogEmployeeJournalItemDto>, IRepositoryCatalogEmployee
{
    private readonly IMapper _mapper;
    public RepositoryCatalogEmployee(ContextProjectManagement dbContext, IMapper mapper)
        : base(dbContext, mapper)
    {
        _mapper = mapper;
    }

    public async Task<List<CatalogEmployeeComboboxDto>> GetListAsync()
    {
        return (await GetAll().ToListAsync())
            .Select(s => _mapper.Map<CatalogEmployeeComboboxDto>(s))
            .ToList();
    }
}