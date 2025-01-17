using ScheduleModule.DomainModels;

namespace ScheduleModule.Repositories.Shared;

public interface IShiftsRepository
{
    Task<IEnumerable<ShiftEmployee>> GetEmployeeShifts(DateOnly date, Guid? employeeId);
    Task<Shift> AddShift(Shift shift);
    Task<Shift> UpdateShift(Shift shift, Guid roleToEmployee);
    Task DeleteShift(Guid shiftId);
}
