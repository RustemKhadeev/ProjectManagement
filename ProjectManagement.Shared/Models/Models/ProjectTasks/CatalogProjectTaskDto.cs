using ProjectManagement.Shared.Models.Interfaces;

namespace ProjectManagement.Shared.Models.Models.ProjectTasks
{
    public class CatalogProjectTaskDto : IHaveId
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StatusId { get; set; } 
        public string Description { get; set; }
        public int Priority { get; set; } = 0;
        public int? AutorId { get; set; }
        public int? ExecutorId { get; set; }
        public int? CatalogProjectId { get; set; }
    }
}
