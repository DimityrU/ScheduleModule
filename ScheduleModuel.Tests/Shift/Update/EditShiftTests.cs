using ScheduleModule.Services;
using ScheduleModule.Services.Dto.DTOs;
using ScheduleModule.Services.Dto.Incoming;
using ScheduleModule.Services.Dto.Outgoing;
using ScheduleModule.Services.Shared;
using ScheduleModule.Tests.Fixtures;
using ScheduleModule.Tests.Utilities.InMemoryTestData;

namespace ScheduleModule.Tests.Shift.Update;

[Collection("MockCollection")]
public partial class EditShiftTests(MockFixture fixture)
{
    private protected readonly IShiftService ShiftService =
        new ShiftService(fixture.ShiftRepositoryMock.Object, fixture.EmployeesRepositoryMock.Object,
            fixture.RolesRepositoryMock.Object, fixture.Mapper);

    [Theory]
    [Trait("EditShift", "Error")]
    [MemberData(nameof(FailTestData))]
    public async Task EditShift_Error_Test(SaveShiftRequest request, SaveShiftResponse expectedResult)
    {
        var response = await ShiftService.EditShift(request);

        Assert.NotNull(response);
        Assert.True(response.HasError);
        Assert.Equal(expectedResult.ErrorMessage ,response.ErrorMessage);
    }

    [Fact]
    [Trait("EditShift", "Successful")]
    public async Task EditShift_Test()
    {
        var request = new SaveShiftRequest
        {
            Shift = new SaveShiftDTO(ShiftTestData.ShiftId, EmployeeTestData.EmployeeId, RoleTestData.RoleId, ShiftTestData.Sunday, ShiftTestData.StartTime, ShiftTestData.EndTime)
        };
        var expectedResult = new SaveShiftResponse
        {
            Shift = new ShiftDTO(ShiftTestData.ShiftId, RoleTestData.Name, ShiftTestData.StartTime, ShiftTestData.EndTime)
        };

        var response = await ShiftService.EditShift(request);

        Assert.NotNull(response);
        Assert.False(response.HasError);
        Assert.Null(response.ErrorMessage);
        Assert.Equal(expectedResult.Shift, response.Shift);
    }
}