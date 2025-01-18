using Microsoft.AspNetCore.Mvc;
using ScheduleModule.Services.Dto;
using ScheduleModule.Services.Dto.Incoming;
using ScheduleModule.Services.Dto.Outgoing;
using ScheduleModule.Services.Shared;

namespace ScheduleModule.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShiftController(IShiftService shiftService) : ControllerBase
    {
        [HttpGet("GetEmployeesShifts/{date}")]
        public async Task<GetEmployeeShiftsResponse> GetEmployeesShifts([FromRoute] DateOnly date)
        {
            var result = await shiftService.GetEmployeesShifts(date);

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

        [HttpDelete("Delete/{shiftId:guid}")]
        public async Task<BaseResponse> DeleteShift([FromRoute] Guid shiftId)
        {
            var response = await shiftService.DeleteShift(shiftId);

            return response;
        }
    }
}
