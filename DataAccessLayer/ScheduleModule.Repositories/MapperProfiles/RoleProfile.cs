using AutoMapper;

namespace ScheduleModule.Repositories.MapperProfiles;

public class RoleProfile : Profile
{
    public RoleProfile()
    {
        CreateMap<DomainModels.Role, Entities.Role>().ReverseMap();
    }

}