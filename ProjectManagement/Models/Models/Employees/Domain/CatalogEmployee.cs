using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using ProjectManagement.Server.Models.Models.Projects.Domain;
using ProjectManagement.Server.Models.Models.ProjectWorkers.Domain;
using ProjectManagement.Shared.Models.Interfaces;

namespace ProjectManagement.Server.Models.Models.Employees.Domain
{
    public class CatalogEmployee : IHaveId
    {
        public int Id { get; set; }

        [DisplayName("Имя")]
        public string? FirstName { get; set; }

        [DisplayName("Фамилия")]
        public string? LastName { get; set; }

        [DisplayName("Отчество")]
        public string? MiddleName { get; set; }

        [NotMapped] public string? DisplayName => $"{LastName} {FirstName} {MiddleName}";

        [DisplayName("Электронная почта")]
        public string? Email { get; set; }

        public virtual List<CatalogProject> Projects { get; set; } 
        public virtual List<CatalogProjectWorker> ProjectWorkers { get; set; } 
    }
}
