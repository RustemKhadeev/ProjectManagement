using ProjectManagement.Shared.Models.Interfaces;

namespace ProjectManagement.Shared.Models.Models.Projects
{
    public class CatalogProjectJournalItemDto : IHaveId
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? CustomerCompanyName { get; set; }
        public string? ExecutorCompanyName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Priority { get; set; } = 0;
    }
}
