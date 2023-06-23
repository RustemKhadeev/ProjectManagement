using ProjectManagement.Shared.Models.Interfaces;
using ProjectManagement.Shared.Models.Models.ProjectTasks;
using ProjectManagement.Shared.Models.Models.ProjectWorkers;

namespace ProjectManagement.Shared.Models.Models.Projects
{
    public class CatalogProjectDto : IHaveId
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? CustomerCompanyName { get; set; }
        public string? ExecutorCompanyName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Priority { get; set; } = 0;
        public List<CatalogProjectWorkerJournalItemDto> ProjectWorkers { get; set; }
        public List<CatalogProjectTaskJournalItemDto> ProjectTasks { get; set; }
    }
}
