using AutoMapper;
using ScheduleModule.Services.MapperProfiles;

namespace ScheduleModule.Tests.Utilities;

public static class AutoMapper
{
    public static IMapper GetMapper => GetMapperConfiguration.CreateMapper();

    private static readonly MapperConfiguration GetMapperConfiguration = new(configuration =>
    {
        configuration.AddProfile<RoleDTOProfile>();
        configuration.AddProfile<ShiftDTOProfile>();
    });

}