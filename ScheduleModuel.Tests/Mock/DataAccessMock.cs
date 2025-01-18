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
            mock.Setup(x => x.GetAll()).ReturnsAsync(EmployeeTestData.GetEmployees);
            return mock;
        }
    }

    public static Mock<IShiftsRepository> ShiftRepositoryMock
    {
        get
        {
            Mock<IShiftsRepository> mock = new();
            mock.Setup(x => x.GetShifts(new DateOnly(2025, 1, 20))).ReturnsAsync(ShiftTestData.GetShifts);
            mock.Setup(x => x.GetShifts(new DateOnly(2025, 1, 27))).ReturnsAsync([ShiftTestData.Shift]);
            return mock;
        }
    }

}