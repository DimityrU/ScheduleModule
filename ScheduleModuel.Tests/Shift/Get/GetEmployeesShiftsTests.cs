using Newtonsoft.Json;
using ScheduleModule.Services;
using ScheduleModule.Services.Dto.Outgoing;
using ScheduleModule.Services.Shared;
using ScheduleModule.Tests.Fixtures;

namespace ScheduleModule.Tests.Shift.Get;

[Collection("MockCollection")]
public partial class GetEmployeesShiftsTests(MockFixture fixture)
{
    private protected readonly IShiftService ShiftService =
        new ShiftService(fixture.ShiftRepositoryMock.Object, fixture.EmployeesRepositoryMock.Object,
            fixture.RolesRepositoryMock.Object, fixture.Mapper);

    [Theory]
    [Trait("GetRolesByEmployeeId", "Successful")]
    [MemberData(nameof(TestData))]
    public async Task GetRolesByEmployeeId_Test(DateOnly date, GetEmployeeShiftsResponse expectedResult)
    {
        var response = await ShiftService.GetEmployeesShifts(date);

        Assert.NotNull(response);
        Assert.False(response.HasError);
        Assert.Null(response.ErrorMessage);

        var expectedJson = JsonConvert.SerializeObject(expectedResult.Employees);
        var actualJson = JsonConvert.SerializeObject(response.Employees);

        Assert.Equal(expectedJson, actualJson);
    }

    [Fact]
    [Trait("GetRolesByEmployeeId", "Error")]
    public async Task GetRolesByEmployeeId_Error_Test()
    {
        var notMonday = new DateOnly(2025, 1, 1);
        var response = await ShiftService.GetEmployeesShifts(notMonday);

        Assert.NotNull(response);
        Assert.True(response.HasError);
        Assert.Equal("Date must be a Monday", response.ErrorMessage);
    }
}