import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { Table } from "reactstrap";
import { getStylist } from "../../data/stylistData";

export default function StylistDetails() {
  const { id } = useParams();
  const navigate = useNavigate();
  const [stylist, setStylist] = useState(null);

  useEffect(() => {
    getStylist(id).then(setStylist);
  }, []);

  console.log(stylist);

  if (!stylist) {
    return null;
  }

  return (
    <div className="container">
      <h2>
        {stylist.firstName} {stylist.lastName}
      </h2>
      <Table>
        <tbody>
          <tr>
            <th scope="row">Email</th>
            <td>{stylist.email}</td>
          </tr>
          <tr>
            <th scope="row">Address</th>
            <td>{stylist.address}</td>
          </tr>
          <tr>
            <th scope="row">Active Member</th>
            <td>{stylist.isActive ? "Yes" : "No"}</td>
          </tr>
        </tbody>
      </Table>
      <h5>Scheduled Appointments</h5>
      {stylist.appointments?.length ? (
        <Table>
          <thead>
            <tr>
              <th>Customer Name</th>
              <th>Services Requested</th>
              <th>Appointment Date</th>
            </tr>
          </thead>
          <tbody>
            {stylist.appointments.map((a) => (
              <tr key={`appointment-${a.id}`}>
                <td>
                  {a.customer.firstName} {a.customer.lastName}
                </td>
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
        <p>No appointments for this stylist</p>
      )}
    </div>
  );
}
