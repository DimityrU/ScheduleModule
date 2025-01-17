namespace ScheduleModule.DomainModels;

public class Shift
{
    public Guid ShiftId { get; set; }
    public Guid EmployeeId { get; set; }
    public DateOnly? Date { get; set; }
    public string FullName { get; set; }
    public string RoleName { get; set; }
    public TimeOnly StartHour { get; set; }
    public TimeOnly EndHour { get; set; }
}