using ProjectManagement.Server.Models.Bases.Interfaces.IBases;
using ProjectManagement.Server.Models.Models.ProjectWorkers.Domain;
using ProjectManagement.Shared.Models.Models.ProjectWorkers;

namespace ProjectManagement.Server.Models.Models.ProjectWorkers.Interfaces
{
    public interface IRepositoryCatalogProjectWorker 
        : IBaseRepositoryHaveJournal<CatalogProjectWorker, CatalogProjectWorkerDto, CatalogProjectWorkerJournalItemDto>
    {
    }
}
