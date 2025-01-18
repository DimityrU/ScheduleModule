namespace ScheduleModule.Tests.Utilities.InMemoryTestData;

public static class ShiftTestData
{
    public static readonly Guid ShiftId = new("D20A5EA5-4273-43C3-B23F-A4C3AD0B19B5");
    public static readonly Guid SecondShiftId = new("284FD6B3-A3CC-45BF-B2C2-DE70BD6C301F");

    public const string Name = "Name Mock";

    public static readonly TimeOnly StartTime = new(8, 0);
    public static readonly TimeOnly EndTime = new(16, 0);

    public static readonly DateOnly Monday = new(2025, 1, 13);
    public static readonly DateOnly Tuesday = new(2025, 1, 14);
    public static readonly DateOnly Wednesday = new(2025, 1, 15);
    public static readonly DateOnly Thursday = new(2025, 1, 16);
    public static readonly DateOnly Friday = new(2025, 1, 17);
    public static readonly DateOnly Saturday = new(2025, 1, 18);
    public static readonly DateOnly Sunday = new(2025, 1, 19);


    public static readonly DateOnly NoShiftDay = new(2025, 2, 19);
    public static readonly DateOnly FullShiftDay = new(2025, 2, 20);

    public static readonly DateOnly MondayWithShifts = new(2025, 1, 20);

    public static readonly DomainModels.ShiftEmployee FullShift = new()
    {
        Date = FullShiftDay,
        StartHour = new TimeOnly(0, 0),
        EndHour = new TimeOnly(23, 59),
    };

    public static readonly DomainModels.ShiftEmployee Shift = new()
    {
        ShiftId = ShiftId, EmployeeId = EmployeeTestData.EmployeeId, FullName = EmployeeTestData.Name,
        Date = Monday, RoleName = RoleTestData.Name,
        StartHour = StartTime,
        EndHour = EndTime,
    };

    public static readonly DomainModels.Shift AddedShift = new()
    {
        ShiftId = ShiftId,
        RoleName = RoleTestData.Name,
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
            Date = Thursday,
            RoleName = RoleTestData.Name,
            StartHour = StartTime,
            EndHour = EndTime,
        }
    ];
}