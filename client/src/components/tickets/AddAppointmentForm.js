import { useEffect, useState } from "react";
import { Button, Form, FormGroup, Input, Label } from "reactstrap";
import { useNavigate } from "react-router-dom/dist";
import { getCustomers } from "../../data/customerData";
import { createAppointment } from "../../data/appointmentData";
import { getStylists } from "../../data/stylistData";

export default function AddAppointmentForm() {
  const navigate = useNavigate();

  const [customers, setCustomers] = useState([]);
  const [stylists, setStylists] = useState([]);
  const [customerId, setCustomerId] = useState(0);
  const [stylistId, setStylistId] = useState(0);
  const [apptDate, setApptDate] = useState("");

  useEffect(() => {
    getCustomers().then(setCustomers);
    getStylists().then(setStylists);
  }, []);

  const submit = (e) => {
    e.preventDefault();

    const newAppointment = {
      customerId,
      stylistId,
      // formats date to include seconds and milliseconds
      appointmentTime: new Date(apptDate).toISOString(),
    };

    createAppointment(newAppointment).then(() => {
      console.log(newAppointment);
      navigate("/appointments");
    });
  };

  return (
    <div className="container">
      <h4>Create New Appointment</h4>
      <Form>
        <FormGroup>
          <Label htmlFor="customerId">Customer</Label>
          <Input
            type="select"
            name="customerId"
            value={customerId}
            onChange={(e) => {
              setCustomerId(parseInt(e.target.value));
            }}
          >
            <option value="0">Choose a Customer</option>
            {customers.map((c) => (
              <option value={c.id}>
                {c.firstName} {c.lastName}
              </option>
            ))}
          </Input>
        </FormGroup>
        <FormGroup>
          <Label htmlFor="stylistId">Stylist</Label>
          <Input
            type="select"
            name="stylistId"
            value={stylistId}
            onChange={(e) => {
              setStylistId(parseInt(e.target.value));
            }}
          >
            <option value="0">Choose a Stylist</option>
            {stylists.map(
              (s) =>
                s.isActive && (
                  <option value={s.id}>
                    {s.firstName} {s.lastName}
                  </option>
                )
            )}
          </Input>
        </FormGroup>
        <FormGroup>
          <Label htmlFor="appointmentTime">Appointment Date and Time</Label>
          <Input
            type="datetime-local"
            name="appointmentTime"
            value={apptDate}
            onChange={(e) => setApptDate(e.target.value)}
          />
        </FormGroup>
        <Button type="submit" onClick={submit}>
          Add Appointment
        </Button>
      </Form>
    </div>
  );
}
