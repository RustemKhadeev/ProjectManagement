using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Server.Models.Bases.Repositories;
using ProjectManagement.Server.Models.Contexts;
using ProjectManagement.Server.Models.Models.ProjectTasks.Domain;
using ProjectManagement.Shared.Models.Bases;
using ProjectManagement.Shared.Models.Models.ProjectTasks;

namespace ProjectManagement.Server.Models.Models.ProjectTasks.Repositories
{
    public class RepositoryCatalogProjectTask
    : BaseRepositoryHaveJournal<CatalogProjectTask, CatalogProjectTaskDto, CatalogProjectTaskJournalItemDto>, Interfaces.IRepositoryCatalogProjectTask
    {
        private readonly IMapper _mapper;
        public RepositoryCatalogProjectTask(ContextProjectManagement dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _mapper = mapper;
        }


        public async Task<List<CatalogProjectTaskComboboxDto>> GetListAsync()
        {
            return (await GetAll().ToListAsync())
                .Select(s => _mapper.Map<CatalogProjectTaskComboboxDto>(s))
                .ToList();
        }

        public async Task<CatalogProjectTask> AddTaskInProject(CatalogProjectTaskDto projectTaskDto)
        {
            var task = await GetByIdAsync(projectTaskDto.Id);
            task.CatalogProjectId = projectTaskDto.CatalogProjectId;

            return await SaveDomainAsync(task); 
        }

        public async Task<CatalogProjectTask> RemoveTaskFromProject(int id)
        {
            var task = await GetByIdAsync(id);
            task.CatalogProjectId = null;

            return await SaveDomainAsync(task);
        }
    }
}
