using ScheduleModule.DomainModels;

namespace ScheduleModule.Repositories.Interfaces;

public interface IShiftsRepository
{
    Task<IEnumerable<Shift>> GetEmployeeShifts(DateOnly date, Guid? employeeId);
    Task<Shift> AddShift(Shift shift);
    Task<Shift> UpdateShift(Shift shift, Guid roleToEmployee);
    Task DeleteShift(Guid shiftId);
}
