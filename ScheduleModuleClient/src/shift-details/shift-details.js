import { Shift } from '../shared/models/shift.js';
import { validateShiftForm } from '../shared/validator.js';
import { serializeTime, serializeDate } from '../shared/date-time-formatters.js';
import BaseProxy from '../shared/proxies/base-proxy.js';
import { SaveShiftRequest } from '../shared/dto/save-shift-request.js';

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

document.getElementById('startHour').value = shift.startHour || '10:00';
document.getElementById('endHour').value = shift.endHour || '16:00';

document.getElementById('backButton').addEventListener('click', (event) => {  
    window.location.href = '../schedule-grid/schedule-grid.html';
});

document.getElementById('saveButton').addEventListener('click', async () => {
  const roleSelect = document.getElementById('roleName').value;
  const startHourInput = document.getElementById('startHour').value;
  const endHourInput = document.getElementById('endHour').value;

  const validationError = validateShiftForm(roleSelect, startHourInput, endHourInput);
  if (validationError) {
    alert(validationError);
    return;
  }

  if(hasChanges(roleSelect, startHourInput, endHourInput)) {
    let request = new SaveShiftRequest();

    request.shift.employeeId = shift.employeeId;
    request.shift.roleId = roleSelect;
    request.shift.startHour = serializeTime(startHourInput);
    request.shift.endHour = serializeTime(endHourInput);
    request.shift.date = serializeDate(shift.date);

    await api.loadConfig();

    if(pageMode == 'create') {
      await api.post('saveShift', request);
    } 
    else {
      request.shift.shiftId = shift.shiftId;
      await api.put('editShift', request);
    }
  }

  window.location.href = '../schedule-grid/schedule-grid.html';
});

async function fetchRoles() {
  await api.loadConfig();
  return await api.get('getRoles', { EmployeeId: shift.employeeId });
};

function hasChanges(role, startHour, endHour) {
  return role != shift.roleId || startHour != shift.startHour || endHour != shift.endHour;
};
