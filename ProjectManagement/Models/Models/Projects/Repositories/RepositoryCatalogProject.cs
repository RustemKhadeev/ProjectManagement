using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Server.Models.Bases.Repositories;
using ProjectManagement.Server.Models.Contexts;
using ProjectManagement.Server.Models.Models.Projects.Domain;
using ProjectManagement.Server.Models.Models.Projects.Interfaces;
using ProjectManagement.Shared.Models.Models.Projects;

namespace ProjectManagement.Server.Models.Models.Projects.Repositories;

public class RepositoryCatalogProject 
    : BaseRepositoryHaveJournal<CatalogProject, CatalogProjectDto, CatalogProjectJournalItemDto>, IRepositoryCatalogProject
{
    private readonly ContextProjectManagement _dbContext;
    private readonly IMapper _mapper;

    public RepositoryCatalogProject(ContextProjectManagement dbContext, IMapper mapper) : base(dbContext, mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public override async Task<CatalogProjectDto> GetDtoByIdAsync(int id)
    {

        try
        {
            var domain = GetWithVirtual().FirstOrDefault(f => f.Id == id);
            if (domain == null)
                throw new ArgumentException($"Entity with identifier {id} is not found.");

            var ret = _mapper.Map<CatalogProjectDto>(domain);
            return await Task.FromResult(ret);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }

    public async Task<List<CatalogProjectComboboxDto>> GetListAsync()
    {
        return (await GetAll().ToListAsync())
            .Select(s => _mapper.Map<CatalogProjectComboboxDto>(s))
            .ToList();
    }

    private IQueryable<CatalogProject> GetWithVirtual()
    {
        var data = _dbContext
            .CatalogProjects
            .Include(i => i.ProjectWorkers)
            .Include(i => i.ProjectTasks)
            ;

        return data;
    }
}