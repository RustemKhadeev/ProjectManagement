using ProjectManagement.Shared.Models.Interfaces;

namespace ProjectManagement.Shared.Models.Models.Employees
{
    public class CatalogEmployeeJournalItemDto : IHaveId
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
    }
}
