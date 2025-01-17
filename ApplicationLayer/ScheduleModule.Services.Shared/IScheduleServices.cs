using ScheduleModule.Services.Dto.Outgoing;

namespace ScheduleModule.Services.Shared;

public interface IShiftService
{
    Task<GetEmployeeShiftsResponse> GetEmployeeShifts(DateOnly date);
}