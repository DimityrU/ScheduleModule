namespace ScheduleModule.Tests.Utilities.InMemoryTestData;

public static class ShiftTestData
{
    public static readonly Guid ShiftId = new("D20A5EA5-4273-43C3-B23F-A4C3AD0B19B5");
    public static readonly Guid SecondShiftId = new("284FD6B3-A3CC-45BF-B2C2-DE70BD6C301F");

    public const string Name = "Name Mock";

    public static readonly TimeOnly StartTime = new(8, 0);
    public static readonly TimeOnly EndTime = new(16, 0);

    public static readonly DomainModels.ShiftEmployee Shift = new()
    {
        ShiftId = ShiftId, EmployeeId = EmployeeTestData.EmployeeId, FullName = EmployeeTestData.Name,
        Date = EmployeeTestData.Monday, RoleName = RoleTestData.Name,
        StartHour = StartTime,
        EndHour = EndTime,
    };

    public static readonly IEnumerable<DomainModels.ShiftEmployee> GetShifts =
    [
        Shift,
        new()
        {
            ShiftId = SecondShiftId,
            EmployeeId = EmployeeTestData.SecondEmployeeId,
            FullName = EmployeeTestData.Name,
            Date = EmployeeTestData.Thursday,
            RoleName = RoleTestData.Name,
            StartHour = StartTime,
            EndHour = EndTime,
        }
    ];
}