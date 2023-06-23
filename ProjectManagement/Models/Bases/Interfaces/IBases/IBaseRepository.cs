using ProjectManagement.Shared.Models.Interfaces;

namespace ProjectManagement.Server.Models.Bases.Interfaces.IBases
{
    public interface IBaseRepository<TDomain>
        where TDomain : IHaveId
    {
        Task<TDomain> InsertAsync(TDomain domain);

        Task UpdateAsync(TDomain domain);

        Task DeleteAsync(TDomain domain);

        Task<TDomain> SaveDomainAsync(TDomain domain);

        IQueryable<TDomain> GetAll();

        Task<TDomain> GetByIdAsync(int id); 
    }
}
