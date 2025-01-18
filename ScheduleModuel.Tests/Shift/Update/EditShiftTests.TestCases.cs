using ScheduleModule.Services.Dto.DTOs;
using ScheduleModule.Services.Dto.Incoming;
using ScheduleModule.Services.Dto.Outgoing;
using ScheduleModule.Tests.Utilities.InMemoryTestData;

namespace ScheduleModule.Tests.Shift.Update;

public partial class EditShiftTests
{
    public static object[] TestEditShift_EmptyEmployeeId_TestCaseParam()
    {
        var request = new SaveShiftRequest()
        {
            Shift = new SaveShiftDTO(ShiftTestData.ShiftId, Guid.Empty, RoleTestData.RoleId, ShiftTestData.Wednesday, ShiftTestData.StartTime, ShiftTestData.EndTime)
        };
        var expectedResult = new SaveShiftResponse()
        {
            HasError = true,
            ErrorMessage = "Invalid request"
        };
        
        return [request, expectedResult];
    }

    public static object[] TestEditShift_EmptyShiftId_TestCaseParam()
    {
        var request = new SaveShiftRequest()
        {
            Shift = new SaveShiftDTO(Guid.Empty, EmployeeTestData.EmployeeId, RoleTestData.RoleId, ShiftTestData.Wednesday, ShiftTestData.StartTime, ShiftTestData.EndTime)
        };
        var expectedResult = new SaveShiftResponse()
        {
            HasError = true,
            ErrorMessage = "Invalid request"
        };

        return [request, expectedResult];
    }

    public static object[] TestEditShift_EmptyRoleId_TestCaseParam()
    {
        var request = new SaveShiftRequest
        {
            Shift = new SaveShiftDTO(ShiftTestData.ShiftId, EmployeeTestData.EmployeeId, Guid.Empty, ShiftTestData.Wednesday, ShiftTestData.StartTime, ShiftTestData.EndTime)
        };
        var expectedResult = new SaveShiftResponse
        {
            HasError = true,
            ErrorMessage = "Invalid request"
        };

        return [request, expectedResult];
    }

    public static object[] TestEditShift_IsOverlapping_TestCaseParam()
    {
        var request = new SaveShiftRequest
        {
            Shift = new SaveShiftDTO(ShiftTestData.ShiftId, EmployeeTestData.EmployeeId, RoleTestData.RoleDevId, ShiftTestData.FullShiftDay, ShiftTestData.StartTime, ShiftTestData.EndTime)
        };
        var expectedResult = new SaveShiftResponse
        {
            HasError = true,
            ErrorMessage = "Shift overlaps with another shift"
        };

        return [request, expectedResult];
    }

    public static object[] TestEditShift_IncorrectHours_TestCaseParam()
    {
        var request = new SaveShiftRequest
        {
            Shift = new SaveShiftDTO(ShiftTestData.ShiftId, EmployeeTestData.EmployeeId, RoleTestData.RoleDevId, ShiftTestData.Wednesday, ShiftTestData.EndTime, ShiftTestData.StartTime)
        };
        var expectedResult = new SaveShiftResponse
        {
            HasError = true,
            ErrorMessage = "Start hour must be before end hour"
        };

        return [request, expectedResult];
    }

    public static object[] TestEditShift_IncorrectRoleToEmployee_TestCaseParam()
    {
        var request = new SaveShiftRequest
        {
            Shift = new SaveShiftDTO(ShiftTestData.ShiftId, EmployeeTestData.SecondEmployeeId, RoleTestData.RoleManagerId, ShiftTestData.Wednesday, ShiftTestData.StartTime, ShiftTestData.EndTime)
        };
        var expectedResult = new SaveShiftResponse
        {
            HasError = true,
            ErrorMessage = "Invalid Role for this employee"
        };

        return [request, expectedResult];
    }

    public static IEnumerable<object[]> FailTestData()
    {
        yield return TestEditShift_EmptyEmployeeId_TestCaseParam();
        yield return TestEditShift_EmptyShiftId_TestCaseParam();
        yield return TestEditShift_EmptyRoleId_TestCaseParam();
        yield return TestEditShift_IsOverlapping_TestCaseParam();
        yield return TestEditShift_IncorrectHours_TestCaseParam();
        yield return TestEditShift_IncorrectRoleToEmployee_TestCaseParam();
    }
}