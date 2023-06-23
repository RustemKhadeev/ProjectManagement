using Microsoft.EntityFrameworkCore;
using ProjectManagement.Server.Models.Bases.Interfaces.IBases;
using ProjectManagement.Shared.Models.Interfaces;

namespace ProjectManagement.Server.Models.Bases.Repositories
{
    public abstract class BaseRepository<TDomain> : IBaseRepository<TDomain> 
        where TDomain : class, IHaveId, new()
    {
        private readonly DbContext _dbContext;

        protected BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TDomain> InsertAsync(TDomain domain)
        {
            try
            {
                _dbContext.Set<TDomain>();
                await _dbContext.AddAsync(domain);
                await _dbContext.SaveChangesAsync();

                return domain;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        public async Task UpdateAsync(TDomain domain)
        {
            _dbContext.Set<TDomain>();
            _dbContext.Update(domain);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TDomain domain)
        {
            _dbContext.Set<TDomain>();
            _dbContext.Remove(domain);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<TDomain> SaveDomainAsync(TDomain domain)
        {
            if (domain == null)
                return default;

            if (domain.Id == 0)
                domain = await InsertAsync(domain);
            else
                await UpdateAsync(domain);

            return domain;
        }

        public IQueryable<TDomain> GetAll()
        {
            return _dbContext.Set<TDomain>();
        }

        public async Task<TDomain> GetByIdAsync(int id)
        {
            var domain = await _dbContext.Set<TDomain>().FindAsync(id);
            if (domain == null)
                throw new ArgumentException($"Entity with identifier {id} is not found.");

            return domain;
        }
    }
}
