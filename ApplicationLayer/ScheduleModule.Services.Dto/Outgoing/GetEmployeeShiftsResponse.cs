using ScheduleModule.Services.Dto.DTOs;

namespace ScheduleModule.Services.Dto.Outgoing
{
    public class GetEmployeeShiftsResponse : BaseResponse
    {
        public List<EmployeeDTO> Employees { get; set; }
    }
}
