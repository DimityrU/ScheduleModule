namespace ScheduleModule.Tests.Utilities.InMemoryTestData;

public static class RoleTestData
{
    public static readonly Guid RoleId = new("8D2A12EC-568B-4EBD-9EBE-86FD12193F90");
    public static readonly Guid RoleManagerId = new("A4417176-E49D-4693-B410-21F095553765");
    public static readonly Guid RoleDevId = new("6A367F66-46B1-44E2-8A04-371D8DC7ED26");

    public const string Name = "Name Mock";
    public const string Manager = "Manager";
    public const string Developer = "Dev";


    public static IEnumerable<DomainModels.Role> GetRoles()
    {
        return new List<DomainModels.Role>
        {
            new()
            {
                RoleId = RoleId,
                RoleName = Name
            },
            new()
            {
                RoleId = RoleManagerId,
                RoleName = Manager
            },
            new()
            {
                RoleId = RoleDevId,
                RoleName = Developer
            }
        };
    }

}