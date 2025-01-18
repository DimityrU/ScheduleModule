using ScheduleModule.Services.Dto.DTOs;
using ScheduleModule.Services.Dto.Outgoing;
using ScheduleModule.Tests.Utilities.InMemoryTestData;

namespace ScheduleModule.Tests.Shift.Get;

public partial class GetEmployeesShiftsTests
{
    public static object[] TestGetEmployeesShifts_AllEmployeeHaveShifts_TestCaseParam()
    {
        var date = new DateOnly(2025, 1, 20);

        var expectedResult = new GetEmployeeShiftsResponse()
        {
            Employees = [
                new EmployeeDTO(EmployeeTestData.EmployeeId, EmployeeTestData.Name,
                    [
                        new WorkDayDTO(ShiftTestData.Monday,
                            [
                                    new ShiftDTO(ShiftTestData.ShiftId, RoleTestData.Name, ShiftTestData.StartTime, ShiftTestData.EndTime)
                            ])
                    ]),
                new EmployeeDTO(EmployeeTestData.SecondEmployeeId, EmployeeTestData.Name,
                [
                    new WorkDayDTO(ShiftTestData.Thursday,
                    [
                        new ShiftDTO(ShiftTestData.SecondShiftId, RoleTestData.Name, ShiftTestData.StartTime, ShiftTestData.EndTime)
                    ])
                ]),
                ]
        };

        return [date, expectedResult];
    }

    public static object[] TestGetEmployeesShifts_SomeEmployeeHaveShifts_TestCaseParam()
    {
        var date = new DateOnly(2025, 1, 27);

        var expectedResult = new GetEmployeeShiftsResponse()
        {
            Employees = [
                new EmployeeDTO(EmployeeTestData.EmployeeId, EmployeeTestData.Name,
                [
                    new WorkDayDTO(ShiftTestData.Monday,
                    [
                        new ShiftDTO(ShiftTestData.ShiftId, RoleTestData.Name, ShiftTestData.StartTime, ShiftTestData.EndTime)
                    ])
                ]),
                new EmployeeDTO(EmployeeTestData.SecondEmployeeId, EmployeeTestData.Name, [])
            ]
        };

        return [date, expectedResult];
    }


    public static IEnumerable<object[]> TestData()
    {
        yield return TestGetEmployeesShifts_AllEmployeeHaveShifts_TestCaseParam();
        yield return TestGetEmployeesShifts_SomeEmployeeHaveShifts_TestCaseParam();
    }
}