using AutoMapper;
using ScheduleModule.Repositories.Shared;
using ScheduleModule.Services.Dto.DTOs;
using ScheduleModule.Services.Dto.Outgoing;
using ScheduleModule.Services.Shared;

namespace ScheduleModule.Services;

public class RolesService(IRolesRepository rolesRepository, IMapper mapper) : IRolesService
{
    public async Task<GetRolesResponse> GetRolesByEmployeeId(Guid employeeId)
    {
        var response = new GetRolesResponse();

        if (employeeId == Guid.Empty)
        {
            response.AddError("Invalid Request");
            return response;
        }

        var roles = await rolesRepository.GetRolesByEmployeeId(employeeId);

        response.Roles = mapper.Map<List<RoleDTO>>(roles);

        return response;
    }
}