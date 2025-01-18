using ScheduleModule.Services;
using ScheduleModule.Services.Shared;
using ScheduleModule.Tests.Fixtures;

namespace ScheduleModule.Tests.Shift.Delete;

[Collection("MockCollection")]
public partial class DeleteShiftTests(MockFixture fixture)
{
    private protected readonly IShiftService ShiftService =
        new ShiftService(fixture.ShiftRepositoryMock.Object, fixture.EmployeesRepositoryMock.Object,
            fixture.RolesRepositoryMock.Object, fixture.Mapper);

    [Fact]
    [Trait("DeleteShift", "Successful")]
    public async Task GetRolesByEmployeeId_Test()
    {
        var shiftId = Guid.NewGuid();

        var response = await ShiftService.DeleteShift(shiftId);

        Assert.NotNull(response);
        Assert.False(response.HasError);
        Assert.Null(response.ErrorMessage);
    }

    [Fact]
    [Trait("DeleteShift", "Error")]
    public async Task GetRolesByEmployeeId_Error_Test()
    {
        var shiftId = Guid.Empty;

        var response = await ShiftService.DeleteShift(shiftId);

        Assert.NotNull(response);
        Assert.True(response.HasError);
        Assert.Equal("Invalid request", response.ErrorMessage);
    }
}