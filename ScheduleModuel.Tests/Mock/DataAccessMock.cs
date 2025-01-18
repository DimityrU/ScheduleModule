using Moq;
using ScheduleModule.Repositories.Shared;
using ScheduleModule.Tests.Utilities.InMemoryTestData;

namespace ScheduleModule.Tests.Mock;

public static class DataAccessMock
{

    public static Mock<IRolesRepository> RolesRepositoryMock
    {
        get
        {
            Mock<IRolesRepository> mock = new();
            mock.Setup(x => x.GetRolesByEmployeeId(It.IsAny<Guid>())).ReturnsAsync(RoleTestData.GetRoles);
            return mock;
        }
    }

    public static Mock<IEmployeesRepository> EmployeesRepositoryMock
    {
        get
        {
            Mock<IEmployeesRepository> mock = new();
            return mock;
        }
    }

    public static Mock<IShiftsRepository> ShiftRepositoryMock
    {
        get
        {
            Mock<IShiftsRepository> mock = new();
            return mock;
        }
    }

}