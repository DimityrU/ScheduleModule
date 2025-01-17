namespace ScheduleModule.DomainModels;

public class WorkDay
{
    public DateOnly? Date { get; set; }
    public List<Shift> Shifts { get; set; }
}