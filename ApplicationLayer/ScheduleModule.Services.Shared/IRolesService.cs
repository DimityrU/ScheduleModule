using ScheduleModule.Services.Dto.Outgoing;

namespace ScheduleModule.Services.Shared;

public interface IRolesService
{
    Task<GetRolesResponse> GetRolesByEmployeeId(Guid employeeId);
}