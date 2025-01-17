using ScheduleModule.Services.Dto.DTOs;

namespace ScheduleModule.Services.Dto.Outgoing
{
    public class SaveShiftResponse : BaseResponse
    {
        public ShiftDTO Shift { get; set; }
    }
}
