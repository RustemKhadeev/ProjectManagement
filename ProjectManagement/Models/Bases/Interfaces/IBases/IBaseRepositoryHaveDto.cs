using ProjectManagement.Shared.Models.Interfaces;

namespace ProjectManagement.Server.Models.Bases.Interfaces.IBases
{
    public interface IBaseRepositoryHaveDto<TDomain, TDto> : IBaseRepository<TDomain>
        where TDomain : class, IHaveId
        where TDto : IHaveId, new()
    {
        Task<TDto> GetDtoByIdAsync(int id);

        Task<TDto> SaveDtoAsync(TDto dto);

        Task<TDto> CreateAndMapToDto();
    }
}
