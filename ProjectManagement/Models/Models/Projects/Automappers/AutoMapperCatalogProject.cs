using AutoMapper;
using ProjectManagement.Server.Models.Models.Projects.Domain;
using ProjectManagement.Shared.Models.Models.Projects;

namespace ProjectManagement.Server.Models.Models.Projects.Automappers
{
    public class AutoMapperCatalogProject : Profile
    {
        public override string ProfileName => "CatalogProject";

        public AutoMapperCatalogProject()
        {
            CreateMap<CatalogProject, CatalogProjectJournalItemDto>();
            CreateMap<CatalogProject, CatalogProjectDto>();
            CreateMap<CatalogProject, CatalogProjectComboboxDto>()
                .ForMember(d => d.Name, s => s.MapFrom(f => f.DisplayName));
            CreateMap<CatalogProjectDto, CatalogProject>()
                .ForMember(d => d.Employees, s => s.Ignore())
                .ForMember(d => d.ProjectWorkers, s => s.Ignore())
                .ForMember(d => d.ProjectTasks, s => s.Ignore())
                ;
        }
    }
}
