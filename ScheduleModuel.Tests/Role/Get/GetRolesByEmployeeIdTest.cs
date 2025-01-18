using ScheduleModule.Services;
using ScheduleModule.Services.Dto.DTOs;
using ScheduleModule.Services.Dto.Outgoing;
using ScheduleModule.Services.Shared;
using ScheduleModule.Tests.Fixtures;
using ScheduleModule.Tests.Utilities.InMemoryTestData;

namespace ScheduleModule.Tests.Role.Get;

[Collection("MockCollection")]
public partial class GetRolesByEmployeeIdTest(MockFixture fixture)
{
    private protected readonly IRolesService RoleService =
        new RolesService(fixture.RolesRepositoryMock.Object, fixture.Mapper);

    [Fact]
    [Trait("GetRolesByEmployeeId", "Successful")]
    public async Task GetRolesByEmployeeId_Test()
    {
        var employeeId = Guid.NewGuid();
        var expectedResult = new GetRolesResponse()
        {
            Roles = [
                new RoleDTO(RoleTestData.RoleId, "Name Mock"),
                new RoleDTO(RoleTestData.RoleManagerId, "Manager"),
                new RoleDTO(RoleTestData.RoleDevId, "Dev"),
            ]
        };

        var response = await RoleService.GetRolesByEmployeeId(employeeId);

        Assert.NotNull(response);
        Assert.False(response.HasError);
        Assert.Equal(expectedResult.Roles, response.Roles);
    }

    [Fact]
    [Trait("GetRolesByEmployeeId", "Error")]
    public async Task GetRolesByEmployeeId_Error_Test()
    {
        var employeeId = Guid.Empty;
        var expectedResult = new GetRolesResponse()
        {
            HasError = true,
            ErrorMessage = "Invalid Request"
        };

        var response = await RoleService.GetRolesByEmployeeId(employeeId);

        Assert.NotNull(response);
        Assert.True(response.HasError);
        Assert.Equal(expectedResult.ErrorMessage, response.ErrorMessage);
    }
}