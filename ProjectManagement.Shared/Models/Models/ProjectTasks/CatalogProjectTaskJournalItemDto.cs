using ProjectManagement.Shared.Models.Interfaces;

namespace ProjectManagement.Shared.Models.Models.ProjectTasks
{
    public class CatalogProjectTaskJournalItemDto : IHaveId
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; } = 0;
        public string AutorName { get; set; }
        public string ExecutorName { get; set; }
        public string ProjectInfo { get; set; }
    }
}
