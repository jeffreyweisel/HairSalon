import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { Button, Form, FormGroup, Input, Label, Table } from "reactstrap";
import { getAppointment } from "../../data/appointmentData";
import {
  addAppointmentService,
  deleteAppointmentService,
} from "../../data/appointmentServicesData";
import { getServices } from "../../data/servicesData";

export default function AppointmentDetails() {
  const { id } = useParams();
  const [appointment, setAppointments] = useState(null);
  const [allServices, setAllServices] = useState([]);
  const [selectedServices, setSelectedServices] = useState([]);
  const navigate = useNavigate();

  useEffect(() => {
    getAppointment(id).then(setAppointments);
  }, []);

  useEffect(() => {
    getServices().then(setAllServices);
  }, []);

  if (!appointment) {
    return null;
  }

  const handleDeleteClick = (serviceId) => {
    // remove deleted service from list
    setAppointments((prevAppointment) => ({
      ...prevAppointment,
      services: prevAppointment.services.filter(
        (service) => service.id !== serviceId
      ),
    }));

    deleteAppointmentService(serviceId);
  };

  const handleCheckboxChange = (serviceId) => {
    // toggle selection status of a service
    setSelectedServices((prevSelectedServices) => {
      if (prevSelectedServices.includes(serviceId)) {
        return prevSelectedServices.filter((id) => id !== serviceId);
      } else {
        return [...prevSelectedServices, serviceId];
      }
    });
  };

  const submit = async () => {
    await Promise.all(
      // takes an array of promises and returns a single promise, waits for promise to be fulfilled before moving to next step
      selectedServices.map(async (serviceId) => {
        const newAppointmentService = {
          appointmentId: appointment.id,
          serviceId: serviceId,
        };

        await addAppointmentService(newAppointmentService);
        console.log(newAppointmentService);
      })
    );

    navigate("/appointments");
  };

  // get existing serviceIds and filter them out so a service is not added to an appointment twice
  const existingServiceIds = appointment.services.map(
    (appointmentService) => appointmentService.serviceId
  );
  const availableServices = allServices.filter(
    (service) => !existingServiceIds.includes(service.id)
  );

  return (
    <div className="container">
      <h4>Appointment {appointment.id} </h4>
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
                  <Button onClick={() => handleDeleteClick(a.id)}>
                    Remove
                  </Button>
                </td>
              </tr>
            ))}
          </tbody>
        </Table>
      ) : (
        <p>Nothing to see here</p>
      )}
      <div className="mt-4">
        <h4>Add Services</h4>
        <Form>
          <FormGroup row>
            {availableServices.map((service) => (
              <FormGroup check inline key={service.id} className="mr-3">
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
            Add
          </Button>
        </Form>
      </div>
    </div>
  );
}
