using AutoMapper;
using ProjectManagement.Server.Models.Models.ProjectWorkers.Domain;
using ProjectManagement.Shared.Models.Models.ProjectWorkers;

namespace ProjectManagement.Server.Models.Models.ProjectWorkers.AutoMappers
{
    public class AutoMapperCatalogProjectWorker : Profile
    {
        public override string ProfileName => "CatalogProjectWorker";

        public AutoMapperCatalogProjectWorker()
        {
            CreateMap<CatalogProjectWorker, CatalogProjectWorkerDto>();
            CreateMap<CatalogProjectWorker, CatalogProjectWorkerJournalItemDto>()
                .ForMember(d => d.EmployeeFullName, s => s.MapFrom(f => $"{f.CatalogEmployee.LastName} {f.CatalogEmployee.FirstName} {f.CatalogEmployee.MiddleName}"));
            CreateMap<CatalogProjectWorkerDto, CatalogProjectWorker>()
                .ForMember(d => d.CatalogEmployee, s => s.Ignore())
                .ForMember(d => d.CatalogProject, s => s.Ignore())
                ;
        }
    }
}
