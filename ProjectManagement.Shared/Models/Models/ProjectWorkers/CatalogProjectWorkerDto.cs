using ProjectManagement.Shared.Models.Interfaces;

namespace ProjectManagement.Shared.Models.Models.ProjectWorkers
{
    public class CatalogProjectWorkerDto : IHaveId
    {
        public int Id { get; set; }
        public int CatalogEmployeeId { get; set; }
        public int CatalogProjectId { get; set; }
    }
}
