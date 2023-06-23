using ProjectManagement.Server.Models.Bases.Interfaces.IBases;
using ProjectManagement.Server.Models.Models.ProjectTasks.Domain;
using ProjectManagement.Shared.Models.Models.ProjectTasks;

namespace ProjectManagement.Server.Models.Models.ProjectTasks.Interfaces
{
    public interface IRepositoryCatalogProjectTask
    : IBaseRepositoryHaveJournal<CatalogProjectTask, CatalogProjectTaskDto, CatalogProjectTaskJournalItemDto>
    {
        Task<List<CatalogProjectTaskComboboxDto>> GetListAsync();
        Task<CatalogProjectTask> AddTaskInProject(CatalogProjectTaskDto projectTaskDto);
        Task<CatalogProjectTask> RemoveTaskFromProject(int id);
    }
}
