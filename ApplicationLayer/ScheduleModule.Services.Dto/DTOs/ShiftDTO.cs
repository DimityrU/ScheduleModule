namespace ScheduleModule.Services.Dto.DTOs;

public record ShiftDTO(
    Guid ShiftId,
    string RoleName,
    TimeOnly StartHour,
    TimeOnly EndHour);