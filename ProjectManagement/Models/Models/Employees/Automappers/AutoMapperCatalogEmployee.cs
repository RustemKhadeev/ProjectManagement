using AutoMapper;
using ProjectManagement.Server.Models.Models.Employees.Domain;
using ProjectManagement.Shared.Models.Models.Employees;

namespace ProjectManagement.Server.Models.Models.Employees.Automappers
{
    public class AutoMapperCatalogEmployee : Profile
    {
        public override string ProfileName => "CatalogEmployee";

        public AutoMapperCatalogEmployee()
        {
            CreateMap<CatalogEmployee, CatalogEmployeeDto>();
            CreateMap<CatalogEmployeeDto, CatalogEmployee>();
            CreateMap<CatalogEmployee, CatalogEmployeeJournalItemDto>()
                .ForMember(d => d.FullName, s => s.MapFrom(f => $"{f.LastName} {f.FirstName} {f.MiddleName}"));
            CreateMap<CatalogEmployee, CatalogEmployeeComboboxDto>()
                .ForMember(d => d.Name, s => s.MapFrom(f => $"{f.LastName} {f.FirstName} {f.MiddleName}"));
        }
    }
}
