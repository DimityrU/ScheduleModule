import { Shift } from '../shared/models/shift.js';
import BaseProxy from '../shared/proxies/base-proxy.js';

const api = new BaseProxy();
const urlParams = new URLSearchParams(window.location.search);

let shift = new Shift(urlParams);

const pageMode = shift.shiftId ? 'edit' : 'create';

document.getElementById('employeeName').value = shift.employeeName;
document.getElementById('shiftDate').value = shift.date;

fetchRoles().then(res => {
  const roleSelect = document.getElementById('roleName');

  res.roles.forEach(role => {
    const option = document.createElement('option');
    option.value = role.roleId;
    option.textContent = role.roleName;

    if (role.roleName === shift.roleName) {
      option.selected = true;
    }

    roleSelect.appendChild(option);
  });
});

document.getElementById('startTime').value = shift.startHour || '10:00';
document.getElementById('endTime').value = shift.endHour || '16:00';

document.getElementById('backButton').addEventListener('click', () => {
  window.location.href = '../schedule-grid/schedule-grid.html';
});

document.getElementById('saveButton').addEventListener('click', () => {
  window.location.href = '../schedule-grid/schedule-grid.html';
});

async function fetchRoles() {
  await api.loadConfig();

  return await api.get('getRoles', { EmployeeId: shift.employeeId });
};
