namespace ScheduleModule.Services.Dto.DTOs;

public record SaveShiftDTO(
    Guid ShiftId,
    Guid EmployeeId,
    Guid RoleId,
    DateOnly Date,
    TimeOnly StartHour,
    TimeOnly EndHour
    );