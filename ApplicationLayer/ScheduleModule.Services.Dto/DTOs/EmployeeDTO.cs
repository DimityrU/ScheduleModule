namespace ScheduleModule.Services.Dto.DTOs;

public record EmployeeDTO(
    Guid EmployeeId,
    string FullName,
    List<WorkDayDTO> WorkDays);