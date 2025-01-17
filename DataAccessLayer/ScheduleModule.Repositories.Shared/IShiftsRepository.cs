using ScheduleModule.DomainModels;

namespace ScheduleModule.Repositories.Shared;

public interface IShiftsRepository
{
    Task<IEnumerable<ShiftEmployee>> GetEmployeeShifts(DateOnly date, Guid? employeeId);
    Task<Shift> AddShift(ShiftEmployee shift, Guid roleToEmployee);
    Task<Shift> UpdateShift(ShiftEmployee shift, Guid roleToEmployee);
    Task DeleteShift(Guid shiftId);
}
