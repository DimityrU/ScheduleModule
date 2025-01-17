using ScheduleModule.DomainModels;

namespace ScheduleModule.Repositories.Shared;

public interface IRolesRepository
{
    Task<IEnumerable<Role>> GetRolesByEmployeeId(Guid employeeId);

    Task<Guid> GetRolesToEmployeesId(Guid employeeId, Guid roleId);

}
