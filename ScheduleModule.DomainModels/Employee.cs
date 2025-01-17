namespace ScheduleModule.DomainModels;

public class Employee
{
    public Guid EmployeeId { get; set; }
    public string FullName { get; set; }
    public IEnumerable<WorkDay> WorkDays { get; set; }
}