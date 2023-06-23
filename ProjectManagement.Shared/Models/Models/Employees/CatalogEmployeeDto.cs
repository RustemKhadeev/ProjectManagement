using ProjectManagement.Shared.Models.Interfaces;
using ProjectManagement.Shared.Models.Models.Projects;

namespace ProjectManagement.Shared.Models.Models.Employees
{
    public class CatalogEmployeeDto : IHaveId
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public string? Email { get; set; }
        public List<CatalogProjectDto> Projects { get; set; }
    }
}
