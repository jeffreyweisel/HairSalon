const apiUrl = "/api/appointments"

// Get appointments
export const getAppointments = () => {
    return fetch(apiUrl).then((r) => r.json());
  };

// Get appointment by Id
export const getAppointment = (id) => {
    return fetch(`${apiUrl}/${id}`).then((r) => r.json());
  };


// Add new appointment to the system
export const createAppointment = (stylist) => {
    return fetch(apiUrl, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(stylist),
    }).then((res) => res.json());
  };