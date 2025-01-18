using ScheduleModule.Services.Dto;
using ScheduleModule.Services.Dto.Incoming;
using ScheduleModule.Services.Dto.Outgoing;

namespace ScheduleModule.Services.Shared;

public interface IShiftService
{
    Task<GetEmployeeShiftsResponse> GetEmployeesShifts(DateOnly date);

    Task<SaveShiftResponse> SaveShift(SaveShiftRequest request);

    Task<SaveShiftResponse> EditShift(SaveShiftRequest request);
    Task<BaseResponse> DeleteShift(Guid shiftId);
}