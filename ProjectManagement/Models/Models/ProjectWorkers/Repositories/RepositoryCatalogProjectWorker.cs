using AutoMapper;
using ProjectManagement.Server.Models.Bases.Repositories;
using ProjectManagement.Server.Models.Contexts;
using ProjectManagement.Server.Models.Models.ProjectWorkers.Domain;
using ProjectManagement.Server.Models.Models.ProjectWorkers.Interfaces;
using ProjectManagement.Shared.Models.Models.ProjectWorkers;

namespace ProjectManagement.Server.Models.Models.ProjectWorkers.Repositories
{
    public class RepositoryCatalogProjectWorker 
        : BaseRepositoryHaveJournal<CatalogProjectWorker, CatalogProjectWorkerDto, CatalogProjectWorkerJournalItemDto>, IRepositoryCatalogProjectWorker
    {
        public RepositoryCatalogProjectWorker(ContextProjectManagement dbContext, IMapper mapper) 
            : base(dbContext, mapper)
        {
        }
    }
}
