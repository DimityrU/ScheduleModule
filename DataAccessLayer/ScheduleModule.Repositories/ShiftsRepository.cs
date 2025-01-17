using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ScheduleModule.Repositories.Entities;
using ScheduleModule.Repositories.Shared;

namespace ScheduleModule.Repositories;

public class ShiftsRepository(ScheduleContext context, IMapper mapper) : IShiftsRepository
{
    public async Task<DomainModels.Shift> AddShift(DomainModels.ShiftEmployee shift, Guid roleToEmployee)
    {
        var entity = mapper.Map<Shift>(shift);

        entity.RolesToEmployeeId = roleToEmployee;

        context.Shifts.Add(entity);
        await context.SaveChangesAsync();

        return mapper.Map<DomainModels.Shift>(entity);
    }

    public async Task DeleteShift(Guid shiftId)
    {
        await context.Shifts.Where(s => s.ShiftId == shiftId).ExecuteDeleteAsync();
    }

    public async Task<IEnumerable<DomainModels.ShiftEmployee>> GetEmployeeShifts(DateOnly date, Guid? employeeId)
    {
        var shifts = await context.Procedures.uspGetShiftsForWeekAsync(date);

        return mapper.Map<IEnumerable<DomainModels.ShiftEmployee>>(shifts);
    }

    public async Task<DomainModels.Shift> UpdateShift(DomainModels.ShiftEmployee shift, Guid roleToEmployee)
    {
        await context.Shifts
            .Where(entity => entity.ShiftId == shift.ShiftId)
            .ExecuteUpdateAsync(entity => entity
                .SetProperty(prop => prop.RolesToEmployeeId, roleToEmployee)
                .SetProperty(prop => prop.StartHour, shift.StartHour)
                .SetProperty(prop => prop.EndHour, shift.EndHour));

        return shift;
    }
}
