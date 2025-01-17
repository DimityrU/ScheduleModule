namespace ScheduleModule.DomainModels;

public class ShiftEmployee : ShiftsDate
{
    public Guid EmployeeId { get; set; }
    public string FullName { get; set; }
}