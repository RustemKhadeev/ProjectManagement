using ProjectManagement.Server.Models.Bases.Interfaces.IBases;
using ProjectManagement.Server.Models.Models.ProjectHeads.Domain;
using ProjectManagement.Shared.Models.Models.ProjectHeads;

namespace ProjectManagement.Server.Models.Models.ProjectHeads.Interfaces
{
    public interface IRepositoryCatalogProjectHead
        : IBaseRepositoryHaveDto<CatalogProjectHead, CatalogProjectHeadDto>
    {
    }
}
