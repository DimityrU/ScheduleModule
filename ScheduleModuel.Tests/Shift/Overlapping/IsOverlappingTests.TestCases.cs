using ScheduleModule.DomainModels;
using ScheduleModule.Tests.Utilities.InMemoryTestData;

namespace ScheduleModule.Tests.Shift.Overlapping;
public partial class IsOverlappingTests
{
    public static object?[] IsOverlapping_NoExistingShift_TesCaseParam()
    {
        var shiftEmployee = new ShiftEmployee()
        {
            EmployeeId = EmployeeTestData.EmployeeId,
            FullName = EmployeeTestData.Name,
            ShiftId = ShiftTestData.ShiftId,
            RoleName = RoleTestData.Name,
            Date = ShiftTestData.NoShiftDay,
            StartHour = ShiftTestData.StartTime,
            EndHour = ShiftTestData.EndTime
        };

        object parameter = new object[] { shiftEmployee };

        return [parameter, false];
    }

    public static object?[] IsOverlapping_SameStartHour_TesCaseParam()
    {
        var shiftEmployee = new ShiftEmployee()
        {
            EmployeeId = EmployeeTestData.EmployeeId,
            FullName = EmployeeTestData.Name,
            ShiftId = ShiftTestData.ShiftId,
            RoleName = RoleTestData.Name,
            Date = ShiftTestData.WorkShiftDay,
            StartHour = new TimeOnly(9, 0),
            EndHour = new TimeOnly(18, 0)
        };

        object parameter = new object[] { shiftEmployee };

        return [parameter, true];
    }

    public static object?[] IsOverlapping_SameEndHour_TesCaseParam()
    {
        var shiftEmployee = new ShiftEmployee()
        {
            EmployeeId = EmployeeTestData.EmployeeId,
            FullName = EmployeeTestData.Name,
            ShiftId = ShiftTestData.ShiftId,
            RoleName = RoleTestData.Name,
            Date = ShiftTestData.WorkShiftDay,
            StartHour = new TimeOnly(8, 0),
            EndHour = new TimeOnly(17, 0)
        };

        object parameter = new object[] { shiftEmployee };

        return [parameter, true];
    }

    public static object?[] IsOverlapping_SameStartHourWithEndHour_TesCaseParam()
    {
        var shiftEmployee = new ShiftEmployee()
        {
            EmployeeId = EmployeeTestData.EmployeeId,
            FullName = EmployeeTestData.Name,
            ShiftId = ShiftTestData.ShiftId,
            RoleName = RoleTestData.Name,
            Date = ShiftTestData.WorkShiftDay,
            StartHour = new TimeOnly(17, 0),
            EndHour = new TimeOnly(18, 0)
        };

        object parameter = new object[] { shiftEmployee };

        return [parameter, true];
    }

    public static object?[] IsOverlapping_SameEndHourWithStartHour_TesCaseParam()
    {
        var shiftEmployee = new ShiftEmployee()
        {
            EmployeeId = EmployeeTestData.EmployeeId,
            FullName = EmployeeTestData.Name,
            ShiftId = ShiftTestData.ShiftId,
            RoleName = RoleTestData.Name,
            Date = ShiftTestData.WorkShiftDay,
            StartHour = new TimeOnly(7, 0),
            EndHour = new TimeOnly(9, 0)
        };

        object parameter = new object[] { shiftEmployee };

        return [parameter, true];
    }

    public static object?[] IsOverlapping_OverlappingWithStartHour_TesCaseParam()
    {
        var shiftEmployee = new ShiftEmployee()
        {
            EmployeeId = EmployeeTestData.EmployeeId,
            FullName = EmployeeTestData.Name,
            ShiftId = ShiftTestData.ShiftId,
            RoleName = RoleTestData.Name,
            Date = ShiftTestData.WorkShiftDay,
            StartHour = new TimeOnly(8, 0),
            EndHour = new TimeOnly(10, 0)
        };

        object parameter = new object[] { shiftEmployee };

        return [parameter, true];
    }

    public static object?[] IsOverlapping_OverlappingWithEndHour_TesCaseParam()
    {
        var shiftEmployee = new ShiftEmployee()
        {
            EmployeeId = EmployeeTestData.EmployeeId,
            FullName = EmployeeTestData.Name,
            ShiftId = ShiftTestData.ShiftId,
            RoleName = RoleTestData.Name,
            Date = ShiftTestData.WorkShiftDay,
            StartHour = new TimeOnly(16, 0),
            EndHour = new TimeOnly(18, 0)
        };

        object parameter = new object[] { shiftEmployee };

        return [parameter, true];
    }

    public static object?[] IsOverlapping_OverlappingInnerHours_TesCaseParam()
    {
        var shiftEmployee = new ShiftEmployee()
        {
            EmployeeId = EmployeeTestData.EmployeeId,
            FullName = EmployeeTestData.Name,
            ShiftId = ShiftTestData.ShiftId,
            RoleName = RoleTestData.Name,
            Date = ShiftTestData.WorkShiftDay,
            StartHour = new TimeOnly(12, 0),
            EndHour = new TimeOnly(16, 0)
        };

        object parameter = new object[] { shiftEmployee };

        return [parameter, true];
    }

    public static object?[] IsOverlapping_OverlappingFullShift_TesCaseParam()
    {
        var shiftEmployee = new ShiftEmployee()
        {
            EmployeeId = EmployeeTestData.EmployeeId,
            FullName = EmployeeTestData.Name,
            ShiftId = ShiftTestData.ShiftId,
            RoleName = RoleTestData.Name,
            Date = ShiftTestData.WorkShiftDay,
            StartHour = new TimeOnly(8, 0),
            EndHour = new TimeOnly(18, 0)
        };

        object parameter = new object[] { shiftEmployee };

        return [parameter, true];
    }

    public static object?[] IsOverlapping_NoOverlappingBeforeShift_TesCaseParam()
    {
        var shiftEmployee = new ShiftEmployee()
        {
            EmployeeId = EmployeeTestData.EmployeeId,
            FullName = EmployeeTestData.Name,
            ShiftId = ShiftTestData.ShiftId,
            RoleName = RoleTestData.Name,
            Date = ShiftTestData.WorkShiftDay,
            StartHour = new TimeOnly(07, 0),
            EndHour = new TimeOnly(08, 0)
        };

        object parameter = new object[] { shiftEmployee };

        return [parameter, false];
    }

    public static object?[] IsOverlapping_NoOverlappingAfterShift_TesCaseParam()
    {
        var shiftEmployee = new ShiftEmployee()
        {
            EmployeeId = EmployeeTestData.EmployeeId,
            FullName = EmployeeTestData.Name,
            ShiftId = ShiftTestData.ShiftId,
            RoleName = RoleTestData.Name,
            Date = ShiftTestData.WorkShiftDay,
            StartHour = new TimeOnly(18, 0),
            EndHour = new TimeOnly(20, 0)
        };

        object parameter = new object[] { shiftEmployee };

        return [parameter, false];
    }

    public static IEnumerable<object?[]> TestData()
    {
        yield return IsOverlapping_NoExistingShift_TesCaseParam();
        yield return IsOverlapping_SameStartHour_TesCaseParam();
        yield return IsOverlapping_SameEndHour_TesCaseParam();
        yield return IsOverlapping_SameStartHourWithEndHour_TesCaseParam();
        yield return IsOverlapping_SameEndHourWithStartHour_TesCaseParam();
        yield return IsOverlapping_OverlappingWithStartHour_TesCaseParam();
        yield return IsOverlapping_OverlappingWithEndHour_TesCaseParam();
        yield return IsOverlapping_OverlappingInnerHours_TesCaseParam();
        yield return IsOverlapping_OverlappingFullShift_TesCaseParam();
        yield return IsOverlapping_NoOverlappingBeforeShift_TesCaseParam();
        yield return IsOverlapping_NoOverlappingAfterShift_TesCaseParam();
    }

}