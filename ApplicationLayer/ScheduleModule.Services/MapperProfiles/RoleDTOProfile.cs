using AutoMapper;
using ScheduleModule.DomainModels;
using ScheduleModule.Services.Dto.DTOs;

namespace ScheduleModule.Services.MapperProfiles;

public class RoleDTOProfile : Profile
{
    public RoleDTOProfile()
    {
        CreateMap<RoleDTO, Role>().ReverseMap();
    }

}