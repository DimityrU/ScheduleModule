using AutoMapper;
using ScheduleModule.DomainModels;
using ScheduleModule.Repositories.Shared;
using ScheduleModule.Services.Dto.DTOs;
using ScheduleModule.Services.Dto.Outgoing;
using ScheduleModule.Services.Shared;

namespace ScheduleModule.Services;

public class ShiftService(IShiftsRepository shiftsRepository, IMapper mapper) : IShiftService
{
    public async Task<GetEmployeeShiftsResponse> GetEmployeeShifts(DateOnly date)
    {
        var response = new GetEmployeeShiftsResponse();

        if (date.DayOfWeek != DayOfWeek.Monday)
        {
            response.AddError("Date must be a Monday");
            return response;
        }

        var shifts = await shiftsRepository.GetEmployeeShifts(date, null);

        var employees = GroupShiftsByEmployee(shifts);

        response.Employees = mapper.Map<List<EmployeeDTO>>(employees);

        return response;
    }

    private static IEnumerable<Employee> GroupShiftsByEmployee(IEnumerable<ShiftEmployee> shifts)
    {
        return shifts
            .GroupBy(shift => new { shift.EmployeeId, shift.FullName })
            .Select(group => new Employee()
            {
                FullName = group.Key.FullName,
                EmployeeId = group.Key.EmployeeId,
                WorkDays = group
                    .GroupBy(g => g.Date)
                    .Select(workDay => new WorkDay
                    {
                        Date = workDay.Key,
                        Shifts = workDay.Select(shift => new Shift
                        {
                            ShiftId = shift.ShiftId,
                            RoleName = shift.RoleName,
                            StartHour = shift.StartHour,
                            EndHour = shift.EndHour
                        }).ToList()
                    }).ToList()
            });
    }
}