using AutoMapper;
using ScheduleModule.DomainModels;
using ScheduleModule.Services.Dto.DTOs;

namespace ScheduleModule.Services.MapperProfiles;

public class ShiftDTOProfile : Profile
{
    public ShiftDTOProfile()
    {
        CreateMap<ShiftDTO, Shift>().ReverseMap();

        CreateMap<WorkDayDTO, WorkDay>()
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
            .ForMember(dest => dest.Shifts, opt => opt.MapFrom(src => src.shifts))
            .ReverseMap();

        CreateMap<EmployeeDTO, Employee>()
            .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId))
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
            .ForMember(dest => dest.WorkDays, opt => opt.MapFrom(src => src.workDays))
            .ReverseMap();
    }

}