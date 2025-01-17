namespace ScheduleModule.DomainModels;

public class Shift
{
    public Guid ShiftId { get; set; }
    public string RoleName { get; set; }
    public TimeOnly StartHour { get; set; }
    public TimeOnly EndHour { get; set; }
}