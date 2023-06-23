using System.ComponentModel.DataAnnotations.Schema;
using ProjectManagement.Server.Models.Models.Employees.Domain;
using ProjectManagement.Server.Models.Models.ProjectTasks.Domain;
using ProjectManagement.Server.Models.Models.ProjectWorkers.Domain;
using ProjectManagement.Shared.Models.Interfaces;

namespace ProjectManagement.Server.Models.Models.Projects.Domain
{
    public class CatalogProject : IHaveId
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [NotMapped] public string? DisplayName => $"{Name} {StartDate}-{EndDate}";
        public string? CustomerCompanyName { get; set; }
        public string? ExecutorCompanyName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Priority { get; set; } = 0;
        public virtual List<CatalogEmployee> Employees { get; set; } 
        public virtual List<CatalogProjectWorker> ProjectWorkers { get; set; } 
        public virtual List<CatalogProjectTask> ProjectTasks { get; set; }
    }
}
