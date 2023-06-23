using ProjectManagement.Shared.Models.Interfaces;

namespace ProjectManagement.Shared.Models.Models.ProjectWorkers
{
    public class CatalogProjectWorkerJournalItemDto : IHaveId
    {
        public int Id { get; set; }
        public string EmployeeFullName { get; set; }
    }
}
