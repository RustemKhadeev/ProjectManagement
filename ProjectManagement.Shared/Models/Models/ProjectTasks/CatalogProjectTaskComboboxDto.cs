using ProjectManagement.Shared.Models.Interfaces;

namespace ProjectManagement.Shared.Models.Models.ProjectTasks
{
    public class CatalogProjectTaskComboboxDto : IHaveIdNulable
    {
        public int? Id { get; set; }
        public string Name { get; set; }
    }
}
