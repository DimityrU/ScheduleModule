using AutoMapper;
using ScheduleModule.DomainModels;
using ScheduleModule.Repositories.Shared;
using ScheduleModule.Services.Dto;
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
    public async Task<GetEmployeeShiftsResponse> GetEmployeesShifts(DateOnly date)
    {
        var response = new GetEmployeeShiftsResponse();

        if (date.DayOfWeek != DayOfWeek.Monday)
        {
            response.AddError("Date must be a Monday");
            return response;
        }

        var shifts = await shiftsRepository.GetShifts(date);

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

        var validateShiftResponse = await ValidateShift(shift, request.Shift.RoleId);

        if (validateShiftResponse.HasError)
        {
            response.AddError(validateShiftResponse.ErrorMessage);
            return response;
        }

        var savedShift = await shiftsRepository.AddShift(shift, validateShiftResponse.RoleToEmployee);

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

        var validateShiftResponse = await ValidateShift(shift, request.Shift.RoleId);

        if (validateShiftResponse.HasError)
        {
            response.AddError(validateShiftResponse.ErrorMessage);
            return response;
        }

        var savedShift = await shiftsRepository.UpdateShift(shift, validateShiftResponse.RoleToEmployee);

        response.Shift = mapper.Map<ShiftDTO>(savedShift);

        return response;
    }

    public async Task<BaseResponse> DeleteShift(Guid shiftId)
    {
        var response = new BaseResponse();

        if (shiftId == Guid.Empty)
        {
            response.AddError("Invalid request");
            return response;
        }

        await shiftsRepository.DeleteShift(shiftId);

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

    private async Task<bool> IsOverlapping(ShiftEmployee shiftEmployee)
    {
        var shifts = (await shiftsRepository.GetEmployeeShifts(shiftEmployee)).ToList();

        if(shifts.Count == 0) return false;
        
        foreach (var shift in shifts)
        {
            if (shift.StartHour == shiftEmployee.StartHour
                || shift.EndHour == shiftEmployee.EndHour
                || shift.StartHour == shiftEmployee.EndHour
                || shift.EndHour == shiftEmployee.StartHour)
            {
                return true;
            }

            if (shift.StartHour > shiftEmployee.StartHour &&
                shift.StartHour < shiftEmployee.EndHour)
            {
                return true;
            }

            if (shift.EndHour > shiftEmployee.StartHour &&
                shift.EndHour < shiftEmployee.EndHour)
            {
                return true;
            }

            if (shift.StartHour < shiftEmployee.StartHour &&
                shift.EndHour > shiftEmployee.EndHour)
            {
                return true;
            }
        }

        return false;
    }

    private async Task<RoleToEmployeeResponse> ValidateShift(ShiftEmployee shift, Guid roleId)
    {
        var response = new RoleToEmployeeResponse();

        if (shift.StartHour > shift.EndHour)
        {
            response.AddError("Start hour must be before end hour");
            return response;
        }

        var isOverlapping = await IsOverlapping(shift);
        if (isOverlapping)
        {
            response.AddError("Shift overlaps with another shift");
            return response;
        }

        var roleToEmployeeId = await rolesRepository.GetRolesToEmployeesId(shift.EmployeeId, roleId);

        if (roleToEmployeeId == Guid.Empty)
        {
            response.AddError("Invalid Role for this employee");
            return response;
        }

        response.RoleToEmployee = roleToEmployeeId;

        return response;
    }
}