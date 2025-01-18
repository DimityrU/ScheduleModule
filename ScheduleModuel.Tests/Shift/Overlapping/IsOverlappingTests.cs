using System.Reflection;
using ScheduleModule.DomainModels;
using ScheduleModule.Services;
using ScheduleModule.Services.Shared;
using ScheduleModule.Tests.Fixtures;

namespace ScheduleModule.Tests.Shift.Overlapping;

[Collection("MockCollection")]
public partial class IsOverlappingTests(MockFixture fixture)
{
    private protected readonly IShiftService ShiftService =
        new ShiftService(fixture.ShiftRepositoryMock.Object, fixture.EmployeesRepositoryMock.Object,
            fixture.RolesRepositoryMock.Object, fixture.Mapper);

    [Theory]
    [Trait("IsOverlapping", "Successful")]
    [MemberData(nameof(TestData))]
    public async Task IsOverlapping_Test(object[] parameter, bool expectedResult)
    {
        var IsOverLappingMethod = typeof(ShiftService).GetMethod("IsOverlapping",
            BindingFlags.NonPublic | BindingFlags.Instance);

        var result = await (Task<bool>)IsOverLappingMethod.Invoke(ShiftService, parameter);

        Assert.Equal(expectedResult, result);
    }
}