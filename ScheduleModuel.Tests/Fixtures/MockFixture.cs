using AutoMapper;
using Moq;
using ScheduleModule.Repositories.Shared;
using ScheduleModule.Services.Shared;
using ScheduleModule.Tests.Mock;

namespace ScheduleModule.Tests.Fixtures;

public class MockFixture : IDisposable
{
    #region Non-Mock Services
    public IMapper Mapper { get; } = Utilities.AutoMapper.GetMapper;
    #endregion

    #region Mock Data Providers

    public Mock<IRolesRepository> RolesRepositoryMock { get; } = DataAccessMock.RolesRepositoryMock;
    public Mock<IEmployeesRepository> EmployeesRepositoryMock { get; } = DataAccessMock.EmployeesRepositoryMock;
    public Mock<IShiftsRepository> ShiftRepositoryMock { get; } = DataAccessMock.ShiftRepositoryMock;


    #endregion

    #region IDisposable Implementation
    public void Dispose()
    {
        ResetAllMocks();
    }

    private void ResetAllMocks()
    {
        RolesRepositoryMock.Reset();
        EmployeesRepositoryMock.Reset();
        ShiftRepositoryMock.Reset();
    }
    #endregion
}
