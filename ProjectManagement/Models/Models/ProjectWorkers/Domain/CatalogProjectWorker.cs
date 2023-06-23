using ProjectManagement.Server.Models.Models.Employees.Domain;
using ProjectManagement.Server.Models.Models.Projects.Domain;
using ProjectManagement.Shared.Models.Interfaces;

namespace ProjectManagement.Server.Models.Models.ProjectWorkers.Domain
{
    public class CatalogProjectWorker : IHaveId
    {
        public int Id { get; set; }
        public int CatalogEmployeeId { get; set; }
        public virtual CatalogEmployee CatalogEmployee { get; set; }
        public int CatalogProjectId { get; set; }
        public virtual  CatalogProject CatalogProject { get; set; }
    }
}
