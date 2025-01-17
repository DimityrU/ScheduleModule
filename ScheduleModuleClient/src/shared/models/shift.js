import { formatDate } from "../date-helpers.js";

export class Shift {
    constructor(urlParams) {
      this.shiftId = urlParams.get('shiftId');
      this.employeeId =  urlParams.get('employeeId');
      this.employeeName = urlParams.get('employeeName');
      this.roleId;
      this.roleName = urlParams.get('roleName');
      this.date = formatDate(urlParams.get('date'));
      this.startHour = urlParams.get('startHour');
      this.endHour = urlParams.get('endHour');
    }
  }
  