using AutoMapper;
using ScheduleModule.DomainModels;
using ScheduleModule.Repositories.Shared;
using ScheduleModule.Services.Dto.DTOs;
using ScheduleModule.Services.Dto.Incoming;
using ScheduleModule.Services.Dto.Outgoing;
using ScheduleModule.Services.Shared;

namespace ScheduleModule.Services;

public class ShiftService(IShiftsRepository shiftsRepository, 
    IEmployeesRepository employeesRepository,
    IRolesRepository rolesRepository,
    IMapper mapper) : IShiftService
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

        var employeesWithShifts = GroupShiftsByEmployee(shifts).ToList();

        var allEmployees = (await employeesRepository.GetAll()).ToList();

        foreach (var employee in allEmployees)
        {
            if (employeesWithShifts.All(e => e.EmployeeId != employee.EmployeeId))
                employeesWithShifts.Add(employee);
        }

        response.Employees = mapper.Map<List<EmployeeDTO>>(employeesWithShifts);

        return response;
    }

    public async Task<SaveShiftResponse> SaveShift(SaveShiftRequest request)
    {
        var response = new SaveShiftResponse();

        if (request.Shift.EmployeeId == Guid.Empty ||
            request.Shift.RoleId == Guid.Empty)
        {
            response.AddError("Invalid request");
            return response;
        }
        var shift = mapper.Map<ShiftEmployee>(request.Shift);

        //Overlapping shifts validation

        //hour check

        var roleToEmployeeId = await rolesRepository.GetRolesToEmployeesId(request.Shift.EmployeeId, request.Shift.RoleId);

        if (roleToEmployeeId == Guid.Empty)
        {
            response.AddError("Invalid Role for this employee");
            return response;
        }

        var savedShift = await shiftsRepository.AddShift(shift, roleToEmployeeId);

        response.Shift = mapper.Map<ShiftDTO>(savedShift);

        return response;
    }

    public async Task<SaveShiftResponse> EditShift(SaveShiftRequest request)
    {
        var response = new SaveShiftResponse();

        if (request.Shift.EmployeeId == Guid.Empty || request.Shift.ShiftId == Guid.Empty ||
            request.Shift.RoleId == Guid.Empty)
        {
            response.AddError("Invalid request");
            return response;
        }
        var shift = mapper.Map<ShiftEmployee>(request.Shift);

        //Overlapping shifts validation

        //hour check

        var roleToEmployeeId = await rolesRepository.GetRolesToEmployeesId(request.Shift.EmployeeId, request.Shift.RoleId);

        if (roleToEmployeeId == Guid.Empty)
        {
            response.AddError("Invalid Role for this employee");
            return response;
        }

        var savedShift = await shiftsRepository.UpdateShift(shift, roleToEmployeeId);

        response.Shift = mapper.Map<ShiftDTO>(savedShift);

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
                        }).OrderBy(x => x.StartHour).ToList()
                    }).OrderBy(x => x.Date).ToList()
            });
    }
}