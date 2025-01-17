import { deserializeDate } from "../date-time-formatters.js";

export class Shift {
    constructor(urlParams) {
      this.shiftId = urlParams?.get('shiftId');
      this.employeeId =  urlParams?.get('employeeId');
      this.employeeName = urlParams?.get('employeeName');
      this.roleId;
      this.roleName = urlParams?.get('roleName');
      this.date = deserializeDate(urlParams?.get('date'));
      this.startHour = urlParams?.get('startHour');
      this.endHour = urlParams?.get('endHour');
    }
  }
  