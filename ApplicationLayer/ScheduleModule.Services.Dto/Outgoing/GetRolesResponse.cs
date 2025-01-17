using ScheduleModule.Services.Dto.DTOs;

namespace ScheduleModule.Services.Dto.Outgoing
{
    public class GetRolesResponse : BaseResponse
    {
        public List<RoleDTO> Roles { get; set; }
    }
}
