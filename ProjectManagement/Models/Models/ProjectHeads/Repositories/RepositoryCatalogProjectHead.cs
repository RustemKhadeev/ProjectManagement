using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Server.Models.Bases.Repositories;
using ProjectManagement.Server.Models.Models.ProjectHeads.Domain;
using ProjectManagement.Server.Models.Models.ProjectHeads.Interfaces;
using ProjectManagement.Shared.Models.Models.ProjectHeads;

namespace ProjectManagement.Server.Models.Models.ProjectHeads.Repositories
{
    public class RepositoryCatalogProjectHead
    : BaseRepositoryHaveDto<CatalogProjectHead, CatalogProjectHeadDto>, IRepositoryCatalogProjectHead
    {
        public RepositoryCatalogProjectHead(DbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
