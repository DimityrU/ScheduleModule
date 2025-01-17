using Microsoft.AspNetCore.Mvc;
using ScheduleModule.Services.Dto.Outgoing;
using ScheduleModule.Services.Shared;

namespace ScheduleModule.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RolesController(IRolesService rolesService) : ControllerBase
    {
        [HttpGet("GetRoles/{employeeId:guid}")]
        public async Task<GetRolesResponse> GetEmployeeShifts(Guid employeeId)
        {
            var result = await rolesService.GetRolesByEmployeeId(employeeId);

            return result;
        }
    }
}
