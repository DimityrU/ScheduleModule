using ScheduleModule.Services.Dto.DTOs;

namespace ScheduleModule.Services.Dto.Outgoing
{
    public class GetEmployeeShifts : BaseResponse
    {
        public List<EmployeeDTO> Employees { get; set; }
    }
}
