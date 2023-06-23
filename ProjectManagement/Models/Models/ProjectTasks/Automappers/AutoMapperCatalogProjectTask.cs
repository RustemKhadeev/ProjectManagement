using AutoMapper;
using ProjectManagement.Server.Models.Models.ProjectTasks.Domain;
using ProjectManagement.Shared.Models.Models.ProjectTasks;

namespace ProjectManagement.Server.Models.Models.ProjectTasks.Automappers
{
    public class AutoMapperCatalogProjectTask : Profile
    {
        public override string ProfileName => "CatalogProjectTask";

        public AutoMapperCatalogProjectTask()
        {
            CreateMap<CatalogProjectTask, CatalogProjectTaskJournalItemDto>()
                .ForMember(d => d.ProjectInfo,
                    s => s.MapFrom(m => m.CatalogProjectId.HasValue ? m.Project.DisplayName : ""))
                .ForMember(d => d.AutorName, s => s.MapFrom(m => m.AutorId.HasValue ? m.Autor.DisplayName : ""))
                .ForMember(d => d.ExecutorName, s => s.MapFrom(m => m.ExecutorId.HasValue ? m.Executor.DisplayName : ""))
                ;
            CreateMap<CatalogProjectTask, CatalogProjectTaskComboboxDto>();
            CreateMap<CatalogProjectTask, CatalogProjectTaskDto>();
            CreateMap<CatalogProjectTaskDto, CatalogProjectTask>()
                .ForMember(d => d.Autor, s => s.Ignore())
                .ForMember(d => d.Executor, s => s.Ignore())
                .ForMember(d => d.Project, s => s.Ignore())
                ;
        }
    }
}
