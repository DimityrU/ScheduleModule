using AutoMapper;

namespace ScheduleModule.Repositories.MapperProfiles;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<Entities.Employee, DomainModels.Employee>()
            .ForMember(dest => dest.FullName,
                opt => opt.MapFrom(src => string.Concat(src.FirstName + " " + src.LastName)));
    }

}