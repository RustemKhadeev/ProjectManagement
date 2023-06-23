using ProjectManagement.Server.Models.Bases.Interfaces.IBases;
using ProjectManagement.Server.Models.Models.Projects.Domain;
using ProjectManagement.Shared.Models.Models.Projects;

namespace ProjectManagement.Server.Models.Models.Projects.Interfaces;

public interface IRepositoryCatalogProject 
    : IBaseRepositoryHaveJournal<CatalogProject, CatalogProjectDto, CatalogProjectJournalItemDto>
{
    Task<List<CatalogProjectComboboxDto>> GetListAsync();
}