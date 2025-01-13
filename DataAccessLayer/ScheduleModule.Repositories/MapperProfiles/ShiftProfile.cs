using AutoMapper;

namespace ScheduleModule.Repositories.MapperProfiles;

public class ShiftProfile : Profile
{
    public ShiftProfile()
    {
        CreateMap<DomainModels.Shift, Entities.Shift>().ReverseMap();

        CreateMap<Entities.spGetShiftsForWeekResult, DomainModels.Shift>()
            .ForMember(model => model.Employee, options => options.MapFrom(entity => entity.FullName));

        CreateMap<DomainModels.Shift, Entities.spGetShiftsForWeekResult>()
            .ForMember(entity => entity.FullName, options => options.MapFrom(model => model.Employee));
    }

}