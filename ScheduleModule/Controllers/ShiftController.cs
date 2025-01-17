using Microsoft.AspNetCore.Mvc;
using ScheduleModule.Services.Dto.Incoming;
using ScheduleModule.Services.Dto.Outgoing;
using ScheduleModule.Services.Shared;

namespace ScheduleModule.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShiftController(IShiftService shiftService) : ControllerBase
    {
        [HttpGet("GetEmployeeShifts/{date}")]
        public async Task<GetEmployeeShiftsResponse> GetEmployeeShifts([FromRoute] DateOnly date)
        {
            var result = await shiftService.GetEmployeeShifts(date);

            return result;
        }

        [HttpPost("Save")]
        public async Task<SaveShiftResponse> SaveShift([FromBody] SaveShiftRequest request)
        {
            var result = await shiftService.SaveShift(request);

            return result;
        }

        [HttpPut("Edit")]
        public async Task<SaveShiftResponse> EditShift([FromBody] SaveShiftRequest request)
        {
            var result = await shiftService.EditShift(request);

            return result;
        }
    }
}
