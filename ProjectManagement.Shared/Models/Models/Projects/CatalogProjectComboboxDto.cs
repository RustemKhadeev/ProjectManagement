using ProjectManagement.Shared.Models.Interfaces;

namespace ProjectManagement.Shared.Models.Models.Projects
{
    public class CatalogProjectComboboxDto : IHaveIdNulable
    {
        public int? Id { get; set; }
        public string Name { get; set; }
    }
}
