using AutoMapper;

namespace ScheduleModule.Repositories.MapperProfiles;

public class ShiftProfile : Profile
{
    public ShiftProfile()
    {
        CreateMap<DomainModels.ShiftEmployee, Entities.uspGetShiftsForWeekResult>().ReverseMap();
    }

}