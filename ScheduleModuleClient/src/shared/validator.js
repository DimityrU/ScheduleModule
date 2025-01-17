export function validateShiftForm(role, startHour, endHour) {
    if (!role) {
      return 'Please select a role';
    }
    const startTimeInMinutes = convertTimeToMinutes(startHour);
    const endTimeInMinutes = convertTimeToMinutes(endHour);
  
    if (startTimeInMinutes >= endTimeInMinutes) {
      return 'Start hour must be before end hour';
    }
  
    return null;
  }

  function convertTimeToMinutes(time) {
    const [hours, minutes] = time.split(':').map(Number);
    return hours * 60 + minutes;
  }