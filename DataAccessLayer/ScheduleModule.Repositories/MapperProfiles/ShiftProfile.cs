using AutoMapper;

namespace ScheduleModule.Repositories.MapperProfiles;

public class ShiftProfile : Profile
{
    public ShiftProfile()
    {
        CreateMap<DomainModels.ShiftEmployee, Entities.uspGetShiftsForWeekResult>().ReverseMap();

        CreateMap<DomainModels.ShiftEmployee, Entities.Shift>().ReverseMap();

        CreateMap<DomainModels.Shift, Entities.Shift>().ReverseMap();
    }

}