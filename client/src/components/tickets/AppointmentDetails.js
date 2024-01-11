import { useEffect, useState } from "react";
import { Link, useNavigate, useParams } from "react-router-dom";
import { Button, Form, FormGroup, Input, Label, Table } from "reactstrap";
import { getAppointment } from "../../data/appointmentData";
import { addAppointmentService, deleteAppointmentService } from "../../data/appointmentServicesData";
import { getServices } from "../../data/servicesData";

export default function AppointmentDetails() {
  const { id } = useParams();
  const [appointment, setAppointments] = useState(null);
  const [allServices, setAllServices] = useState([]);
  const [selectedServices, setSelectedServices] = useState([])
  const navigate = useNavigate();

  useEffect(() => {
    getAppointment(id).then(setAppointments);
  }, []);

  useEffect(() => {
    getServices().then(setAllServices)
  }, [])

  if (!appointment) {
    return null;
  }

  const handleDeleteClick = (serviceId) => {
    // remove deleted service from list
    setAppointments((prevAppointment) => ({
      ...prevAppointment,
      services: prevAppointment.services.filter((service) => service.id !== serviceId),
    }));

    deleteAppointmentService(serviceId);
  };

  const handleCheckboxChange = (serviceId) => {
    // Toggle the selection status of the service
    setSelectedServices((prevSelectedServices) => {
      if (prevSelectedServices.includes(serviceId)) {
        return prevSelectedServices.filter((id) => id !== serviceId);
      } else {
        return [...prevSelectedServices, serviceId];
      }
    });
  };

  const submit = (e) => {
    e.preventDefault();

    // creste new AppointmentService for each of the selected services
    selectedServices.forEach((serviceId) => {
      const newAppointmentService = {
        appointmentId: appointment.id,
        serviceId: serviceId,
      };

      addAppointmentService(newAppointmentService).then(() => {
        console.log(newAppointmentService);
      });
    });

    navigate("/appointments");
  };

  

  return (
    <div className="container">
      <h2>Appointment {appointment.id} </h2>
      <Table>
        <tbody>
          <tr>
            <th scope="row">Stylist</th>
            <td>
              {appointment.stylist.firstName} {appointment.stylist.lastName}
            </td>
          </tr>
          <tr>
            <th scope="row">Customer</th>
            <td>
              {appointment.customer.firstName} {appointment.customer.lastName}
            </td>
          </tr>
          <tr></tr>
        </tbody>
      </Table>
      <div className="sub-menu bg-light d-flex">
        <div>
          <h4>Scheduled Services</h4>
        </div>
      </div>
      {appointment.services?.length ? (
        <Table>
          <thead>
            <tr>
              <th>Service Name</th>
              <th>Service Price</th>
            </tr>
          </thead>
          <tbody>
            {appointment.services.map((a) => (
              <tr key={`service-${a.service.id}`}>
                <td>{a.service.name}</td>
                <td>{a.service.price}</td>
                <td>
                  <Button onClick={() => handleDeleteClick(a.id)}>Remove from appt</Button>
                </td>
              </tr>
            ))}
          </tbody>
        </Table>
      ) : (
        <p>Nothing to see here</p>
      )}
       {/* Add Services Section */}
       <div className="mt-4">
        <h4>Add Services</h4>
        <Form>
          <FormGroup>
            {allServices.map((service) => (
              <FormGroup check key={service.id}>
                <Label check>
                  <Input
                    type="checkbox"
                    id={`service-${service.id}`}
                    checked={selectedServices.includes(service.id)}
                    onChange={() => handleCheckboxChange(service.id)}
                  />
                  {service.name}
                </Label>
              </FormGroup>
            ))}
          </FormGroup>
          <Button color="primary" onClick={submit}>
            Add Selected Services
          </Button>
        </Form>
      </div>
    </div>
  );
}
