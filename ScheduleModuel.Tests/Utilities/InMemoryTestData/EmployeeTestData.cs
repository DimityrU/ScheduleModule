namespace ScheduleModule.Tests.Utilities.InMemoryTestData;

public static class EmployeeTestData
{
    public static readonly Guid EmployeeId = new("0721092d-8aba-454f-8457-f6603ced5418");
    public static readonly Guid SecondEmployeeId = new("0DCF864B-556D-4DB9-8015-6584EB7FC2D8");

    public const string Name = "Name Mock";
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