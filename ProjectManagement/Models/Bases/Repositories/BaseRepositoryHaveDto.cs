using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Server.Models.Bases.Interfaces.IBases;
using ProjectManagement.Shared.Models.Interfaces;

namespace ProjectManagement.Server.Models.Bases.Repositories
{
    public abstract class BaseRepositoryHaveDto<TDomain, TDto> 
        : BaseRepository<TDomain>, IBaseRepositoryHaveDto<TDomain, TDto>
        where TDomain : class, IHaveId, new() 
        where TDto : IHaveId, new()
    {
        private readonly IMapper _mapper;

        protected BaseRepositoryHaveDto(
            DbContext dbContext,
            IMapper mapper) 
            : base(dbContext)
        {
            _mapper = mapper;
        }

        public virtual async Task<TDto> GetDtoByIdAsync(int id)
        {
            var doamin = await GetByIdAsync(id);
            return await MapToDtoAsync(doamin);
        }

        public async Task<TDto> SaveDtoAsync(TDto dto)
        {
            if (dto == null)
                return default;

            TDomain domainObj;
            if (dto.Id == 0)
            {
                domainObj = _mapper.Map<TDomain>(dto);
                domainObj = await SaveDomainAsync(domainObj);
            }
            else
            {
                domainObj = await GetByIdAsync(dto.Id);
                _mapper.Map(dto, domainObj);
                await SaveDomainAsync(domainObj);
            }

            return await MapToDtoAsync(domainObj);
        }

        public async Task<TDto> CreateAndMapToDto()
        {
            var domain = await InsertAsync(new TDomain());
            return await MapToDtoAsync(domain);
        }

        protected async Task<TDto> MapToDtoAsync(TDomain domain)
        {
            var ret = _mapper.Map<TDto>(domain);
            return await Task.FromResult(ret);
        }
    }
}
