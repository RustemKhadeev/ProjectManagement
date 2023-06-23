using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Server.Models.Bases.Interfaces.IBases;
using ProjectManagement.Shared.Models.Interfaces;

namespace ProjectManagement.Server.Models.Bases.Repositories
{
    public abstract class BaseRepositoryHaveJournal<TDomain, TDomainDto, TJournalDto> 
        : BaseRepositoryHaveDto<TDomain, TDomainDto>, IBaseRepositoryHaveJournal<TDomain, TDomainDto, TJournalDto> 
        where TDomain : class, IHaveId, new()
        where TDomainDto : IHaveId, new()
        where TJournalDto : class, IHaveId, new()
    {
        private readonly IMapper _mapper;

        protected BaseRepositoryHaveJournal(
            DbContext dbContext,
            IMapper mapper) : base(dbContext, mapper)
        {
            _mapper = mapper;
        }

        public async Task<List<TJournalDto>> GetAllDtoAsync()
        {
            return (await GetAll().ToListAsync())
                .Select(async s => await MapToJournalDtoAsync(s))
                .Select(q => q.Result)
                .ToList();
        }

        protected async Task<TJournalDto> MapToJournalDtoAsync(TDomain domain)
        {
            var ret = _mapper.Map<TJournalDto>(domain);
            return await Task.FromResult(ret);
        }
    }
}
