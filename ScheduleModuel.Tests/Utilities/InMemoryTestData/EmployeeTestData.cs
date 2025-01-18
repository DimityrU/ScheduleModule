namespace ScheduleModule.Tests.Utilities.InMemoryTestData;

public static class EmployeeTestData
{
    public static readonly Guid EmployeeId = new("0721092d-8aba-454f-8457-f6603ced5418");
    public static readonly Guid SecondEmployeeId = new("0DCF864B-556D-4DB9-8015-6584EB7FC2D8");

    public const string Name = "Name Mock";

    public static readonly DateOnly Monday = new(2025, 1, 13);
    public static readonly DateOnly Tuesday = new(2025, 1, 14);
    public static readonly DateOnly Wednesday = new(2025, 1, 15);
    public static readonly DateOnly Thursday = new(2025, 1, 16);
    public static readonly DateOnly Friday = new(2025, 1, 17);
    public static readonly DateOnly Saturday = new(2025, 1, 18);
    public static readonly DateOnly Sunday = new(2025, 1, 19);

    public static readonly DateOnly MondayWithShifts = new(2025, 1, 20);

    public static IEnumerable<DomainModels.Employee> GetEmployees()
    {
        return new List<DomainModels.Employee>
        {
            new()
            {
                EmployeeId = EmployeeId,
                FullName = Name
            },
            new()
            {
                EmployeeId = SecondEmployeeId,
                FullName = Name
            }
        };
    }
}