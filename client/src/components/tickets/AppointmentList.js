import { useEffect, useState } from "react";
import { Card, CardBody, CardTitle, CardText, Button } from "reactstrap";
import { cancelAppointment, getAppointments } from "../../data/appointmentData";
import { Link } from "react-router-dom";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faClock, faDollarSign, faTimes } from "@fortawesome/free-solid-svg-icons";

export default function AppointmentList() {
  const [appointments, setAppointments] = useState([]);

  useEffect(() => {
    getAppointments().then(setAppointments);
  }, []);

  const handleCancelButtonClick = async (id) => {
    console.log("Deleting appointment with ID:", id);
    await cancelAppointment(id);
    const updatedAppts = await getAppointments();
    setAppointments(updatedAppts);
  };
  
  return (
    <div className="container">
       <div className="sub-menu bg-light d-flex">
      <div>
        <h4>Appointments</h4>
      </div>
      <Link to="/appointments/create" className="ml-2">
        Add
      </Link>
    </div>
      {appointments.map((appointment) => (
        <Card key={`appointment-${appointment.id}`} className="mb-3">
          <CardBody>
            <CardTitle tag="h5">Appointment {appointment.id} {" "}
            <small className="text-muted">
                <Link to={`${appointment.id}`}>Details</Link>
              </small>
            </CardTitle>
            <CardText>
              <strong>Stylist:</strong> {appointment.stylist.firstName}{" "}
              {appointment.stylist.lastName}
              <br />
              <strong>Customer:</strong> {appointment.customer.firstName}{" "}
              {appointment.customer.lastName}
              <br />
              <strong>Service Requested: </strong>
              {appointment.services.map((service) => (
                <span key={`service-${service.id}`}>
                  {service.service.name}
                  <br />
                </span>
              ))}
              <strong><FontAwesomeIcon icon={faClock} /></strong> {appointment.appointmentTime}

              <br />
              <strong><FontAwesomeIcon icon={faDollarSign} /></strong> {appointment.appointmentPrice}
              <br />
              <Button
                  size="sm"
                  color="secondary"
                  className="mt-2"
                  onClick={() => handleCancelButtonClick(appointment.id)}
                >
                  <FontAwesomeIcon icon={faTimes} /> Cancel Appointment
                </Button>
            </CardText>
          </CardBody>
        </Card>
      ))}
    </div>
  );
}
