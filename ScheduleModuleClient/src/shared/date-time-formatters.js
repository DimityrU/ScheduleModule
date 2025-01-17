
  export function getWeekDates(mondayDate) {
    const dates = [];
    const monday = new Date(mondayDate);
    for (let i = 0; i < 7; i++) {
      const date = new Date(monday);
      date.setDate(monday.getDate() + i);
      dates.push(date.toISOString().split('T')[0]);
    }
    return dates;
  }
  
  export function getMondayOfCurrentWeek() {
    const today = new Date();
    const day = today.getDay();
    const diff = today.getDate() - day + (day === 0 ? -6 : 1);
    const monday = new Date(today.setDate(diff));

    const year = monday.getFullYear();
    const month = (monday.getMonth() + 1).toString().padStart(2, '0');
    const dayOfMonth = monday.getDate().toString().padStart(2, '0');
    
    return `${year}-${month}-${dayOfMonth}`;
}

export function serializeTime(time) {
  return `${time}:00`;
}

export function deserializeTime(time) {
  return time.substring(0, 5);
}

export function serializeDate(dateString) {
  const [day, month, year] = dateString.split('.');
  return `${year}-${month}-${day}`;
}

export function deserializeDate(dateString) {
  const date = new Date(dateString);

  const day = String(date.getDate()).padStart(2, '0');
  const month = String(date.getMonth() + 1).padStart(2, '0');
  const year = date.getFullYear();

  return `${day}.${month}.${year}`;
}
