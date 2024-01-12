const apiUrl = "/api/appointmentservices";

// Get appointment services
export const getAppointmentServices = () => {
  return fetch(apiUrl).then((r) => r.json());
};

// Add new appointment service to the system
export const addAppointmentService = (appointmentService) => {
  return fetch(apiUrl, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(appointmentService),
  }).then((res) => res.json());
};

// Delete service from appointment
export const deleteAppointmentService = (serviceId) => {
  return fetch(`${apiUrl}/${serviceId}`, {
    method: "DELETE",
  }).then((res) => res.json());
};
