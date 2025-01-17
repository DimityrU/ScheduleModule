using Microsoft.AspNetCore.Mvc;
using ScheduleModule.Services.Dto.Outgoing;
using ScheduleModule.Services.Shared;

namespace ScheduleModule.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShiftController(IShiftService shiftService) : ControllerBase
    {
        [HttpGet("GetEmployeeShifts/{date:datetime}")]
        public Task<GetEmployeeShifts> GetEmployeeShifts(DateOnly date)
        {
            var result = shiftService.GetEmployeeShifts(date);

            return result;
        }
    }
}
