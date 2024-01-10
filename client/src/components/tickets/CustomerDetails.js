import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { Table } from "reactstrap";
import { getCustomer } from "../../data/customerData";


export default function CustomerDetails() {
  const { id } = useParams();
  const [customer, setCustomer] = useState(null);

  useEffect(() => {
    getCustomer(id).then(setCustomer);
  }, []);

  if (!customer) {
    return null;
  }

  return (
    <div className="container">
      <h2>
        {customer.firstName} {customer.lastName}
      </h2>
      <Table>
        <tbody>
          <tr>
            <th scope="row">Email</th>
            <td>{customer.email}</td>
          </tr>
          <tr>
            <th scope="row">Address</th>
            <td>{customer.address}</td>
          </tr>
          <tr>
          </tr>
        </tbody>
      </Table>
      <h5>Scheduled Appointments</h5>
      {customer.appointments?.length ? (
        <Table>
          <thead>
            <tr>
              <th>Stylist Name</th>
              <th>Services Requested</th>
              <th>Appointment Date</th>
            </tr>
          </thead>
          <tbody>
            {customer.appointments.map((a) => (
              <tr key={`appointment-${a.id}`}>
                <td>{a.stylist.firstName} {a.stylist.lastName}</td>
                <td>
                  {a.services.map((service) => (
                    <span key={`service-${service.id}`}>
                      {service.service.name}
                      <br />
                    </span>
                  ))}
                </td>

                <td>{a.appointmentTime}</td>
              </tr>
            ))}
          </tbody>
        </Table>
      ) : (
        <p>No appointments for this customer</p>
      )}
    </div>
  );
}
