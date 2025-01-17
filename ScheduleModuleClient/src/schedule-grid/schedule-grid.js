import { getMondayOfCurrentWeek, getWeekDates, deserializeDate, deserializeTime } from '../shared/date-time-formatters.js';
import BaseProxy from '../shared/proxies/base-proxy.js';

let currentMonday = getMondayOfCurrentWeek();
const api = new BaseProxy();

createTable();

function createTable() {

  const table = document.getElementById("scheduleTable");
  table.innerHTML = '';

  const dates = getWeekDates(currentMonday);

  const thead = document.createElement("thead");
  const headerRow = document.createElement("tr");
  const userHeader = document.createElement("th");
  userHeader.textContent = "Employee";
  headerRow.appendChild(userHeader);

  dates.forEach(date => {
    const th = document.createElement("th");
    th.classList.add("text-center", "align-middle");
    th.textContent = deserializeDate(date);
    headerRow.appendChild(th);
  });

  thead.appendChild(headerRow);
  table.appendChild(thead);

  const tbody = document.createElement("tbody");

  api.loadConfig().then(() => {
    api.get('getShifts', { Date: currentMonday }).then(data => {
      const employees = data.employees;


      employees.forEach(employee => {
        const row = document.createElement("tr");

        const employeeCell = document.createElement("td");
        employeeCell.classList.add("align-middle");
        employeeCell.textContent = employee.fullName;
        row.appendChild(employeeCell);

      

        dates.forEach(date => {
          const cell = document.createElement("td");

          const addShiftButton = document.createElement("button");
          addShiftButton.classList.add("btn", "btn-primary", "btn-sm");
          addShiftButton.textContent = "+";
          addShiftButton.onclick = () => {
            window.location.href = `../shift-details/shift-details.html?employeeId=${employee.employeeId}&date=${date}&employeeName=${employee.fullName}`;
          };

          cell.appendChild(addShiftButton);

          const workDay = employee.workDays.find(day => day.date === date);
          if (workDay) {
            workDay.shifts.forEach(shift => {

              let startHour = deserializeTime(shift.startHour);
              let endHour = deserializeTime(shift.endHour);

              const shiftFormatted = `${shift.roleName}: ${startHour} - ${endHour}`;

              const shiftElement = document.createElement("div");
              shiftElement.innerHTML = `<a href="../shift-details/shift-details.html?shiftId=${shift.shiftId}&employeeId=${employee.employeeId}&employeeName=${employee.fullName}&roleName=${shift.roleName}&date=${date}&startHour=${startHour}&endHour=${endHour}" class="shift-link">${shiftFormatted}</a>`;
              cell.appendChild(shiftElement);
            });
          }

          row.appendChild(cell);
        });

        tbody.appendChild(row);
      });

      table.appendChild(tbody);

    });
  });
}

document.getElementById("prevWeek").addEventListener("click", () => {
  const monday = new Date(currentMonday);
  monday.setDate(monday.getDate() - 7);
  currentMonday = monday.toISOString().split('T')[0];
  createTable();
});

document.getElementById("nextWeek").addEventListener("click", () => {
  const monday = new Date(currentMonday);
  monday.setDate(monday.getDate() + 7);
  currentMonday = monday.toISOString().split('T')[0];
  createTable();
});

