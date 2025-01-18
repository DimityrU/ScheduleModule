using ScheduleModule.DomainModels;

namespace ScheduleModule.Repositories.Shared;

public interface IShiftsRepository
{
    Task<IEnumerable<ShiftEmployee>> GetShifts(DateOnly date);
    Task<Shift> AddShift(ShiftEmployee shift, Guid roleToEmployee);
    Task<Shift> UpdateShift(ShiftEmployee shift, Guid roleToEmployee);
    Task DeleteShift(Guid shiftId);
    Task<IEnumerable<ShiftEmployee>> GetEmployeeShifts(ShiftEmployee shiftEmployee);

}
