using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ScheduleModule.Repositories.Entities;
using ScheduleModule.Repositories.Shared;

namespace ScheduleModule.Repositories;

public class ShiftsRepository(ScheduleContext context, IMapper mapper) : IShiftsRepository
{
    public async Task<DomainModels.Shift> AddShift(DomainModels.Shift shift)
    {
        var entity = mapper.Map<Shift>(shift);

        context.Shifts.Add(entity);
        await context.SaveChangesAsync();

        return mapper.Map<DomainModels.Shift>(entity);
    }

    public async Task DeleteShift(Guid shiftId)
    {
        await context.Shifts.Where(s => s.ShiftId == shiftId).ExecuteDeleteAsync();
    }

    public async Task<IEnumerable<DomainModels.Shift>> GetEmployeeShifts(DateOnly date, Guid? employeeId)
    {
        var shifts = await context.Procedures.uspGetShiftsForWeekAsync(date);

        return mapper.Map<IEnumerable<DomainModels.Shift>>(shifts);
    }

    public async Task<DomainModels.Shift> UpdateShift(DomainModels.Shift shift, Guid roleToEmployee)
    {
        await context.Shifts
            .ExecuteUpdateAsync(entity => entity
                .SetProperty(prop => prop.RolesToEmployeeId, roleToEmployee)
                .SetProperty(prop => prop.StartHour, shift.StartHour)
                .SetProperty(prop => prop.EndHour, shift.EndHour));

        return shift;
    }
}
