using AutoMapper;

namespace ScheduleModule.Repositories.MapperProfiles;

public class ShiftProfile : Profile
{
    public ShiftProfile()
    {
        CreateMap<DomainModels.Shift, Entities.uspGetShiftsForWeekResult>().ReverseMap();
    }

}