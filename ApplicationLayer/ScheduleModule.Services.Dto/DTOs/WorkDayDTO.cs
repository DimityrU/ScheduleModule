namespace ScheduleModule.Services.Dto.DTOs;

public record WorkDayDTO(
    DateOnly? Date,
    List<ShiftDTO> Shifts);