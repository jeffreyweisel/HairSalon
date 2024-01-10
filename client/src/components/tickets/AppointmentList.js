import { useEffect, useState } from "react";
import { Card, CardBody, CardTitle, CardText } from "reactstrap";
import { getAppointments } from "../../data/appointmentData";

export default function AppointmentList() {
  const [appointments, setAppointments] = useState([]);

  useEffect(() => {
    getAppointments().then(setAppointments);
  }, []);

  return (
    <div className="container">
      <div className="sub-menu bg-light">
        <h4>Appointments</h4>
      </div>
      {appointments.map((appointment) => (
        <Card key={`appointment-${appointment.id}`} className="mb-3">
          <CardBody>
            <CardTitle tag="h5">Appointment {appointment.id}</CardTitle>
            <CardText>
              <strong>Stylist:</strong> {appointment.stylist.firstName}{" "}
              {appointment.stylist.lastName}
              <br />
              <strong>Customer:</strong> {appointment.customer.firstName}{" "}
              {appointment.customer.lastName}
              <br />
              <strong>Services: </strong>
              {appointment.services.map((service) => (
                <span key={`service-${service.id}`}>
                  {service.service.name}
                  <br />
                </span>
              ))}
              <strong>Appointment Date:</strong> {appointment.appointmentTime}
              <br />
              <strong>Total Price:</strong> ${appointment.appointmentPrice}
            </CardText>
          </CardBody>
        </Card>
      ))}
    </div>
  );
}
