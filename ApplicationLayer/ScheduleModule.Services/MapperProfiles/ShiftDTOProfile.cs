using AutoMapper;
using ScheduleModule.DomainModels;
using ScheduleModule.Services.Dto.DTOs;

namespace ScheduleModule.Services.MapperProfiles;

public class ShiftDTOProfile : Profile
{
    public ShiftDTOProfile()
    {
        CreateMap<ShiftDTO, Shift>().ReverseMap();

        CreateMap<WorkDayDTO, WorkDay>().ReverseMap();

        CreateMap<EmployeeDTO, Employee>().ReverseMap();
    }

}