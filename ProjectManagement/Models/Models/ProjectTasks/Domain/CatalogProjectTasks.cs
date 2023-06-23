using System.ComponentModel.DataAnnotations.Schema;
using ProjectManagement.Server.Models.Models.Employees.Domain;
using ProjectManagement.Server.Models.Models.Projects.Domain;
using ProjectManagement.Shared.Enums;
using ProjectManagement.Shared.Models.Interfaces;

namespace ProjectManagement.Server.Models.Models.ProjectTasks.Domain
{
    public class CatalogProjectTask : IHaveId
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int StatusId { get; set; } = 0;
        public string? Description { get; set; }
        public int Priority { get; set; } = 0;
        public int? AutorId { get; set; }
        public virtual CatalogEmployee Autor { get; set; }
        public int? ExecutorId { get; set; }
        public virtual CatalogEmployee Executor { get; set; }
        public int? CatalogProjectId { get; set; }
        public virtual CatalogProject Project { get; set; }
    }
}
