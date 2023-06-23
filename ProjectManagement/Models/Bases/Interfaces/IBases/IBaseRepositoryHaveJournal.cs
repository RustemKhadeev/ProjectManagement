using ProjectManagement.Shared.Models.Interfaces;

namespace ProjectManagement.Server.Models.Bases.Interfaces.IBases
{
    public interface IBaseRepositoryHaveJournal<TDomain, TDomainDto, TJournalDto> : IBaseRepositoryHaveDto<TDomain, TDomainDto> 
        where TDomainDto : IHaveId, new() 
        where TDomain : class, IHaveId
        where TJournalDto : class, IHaveId
    {
        Task<List<TJournalDto>> GetAllDtoAsync();
    }
}
