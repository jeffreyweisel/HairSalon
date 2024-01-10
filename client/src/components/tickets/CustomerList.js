import { useEffect, useState } from "react";
import { Card, CardBody, CardText, CardTitle } from "reactstrap";
import { Link } from "react-router-dom";
import { getCustomers } from "../../data/customerData";


export default function CustomerList() {
  const [customers, setCustomers] = useState([]);

  useEffect(() => {
    getCustomers().then(setCustomers);
  }, []);

  return (
    <div className="container">
      <div className="sub-menu bg-light">
        <h4>Customers</h4>
      </div>
      {customers.map((customer) => (
        <Card key={`customer-${customer.id}`} className="mb-3">
          <CardBody>
          <CardTitle tag="h5">
            {customer.firstName} {customer.lastName}{' '}
            <small className="text-muted">
              <Link to={`${customer.id}`}>Details</Link>
            </small>
          </CardTitle>
            <CardText>
              <strong>Email:</strong> {customer.email} <br />
              <strong>Address:</strong> {customer.address} <br />
            </CardText>
          </CardBody>
        </Card>
      ))}
    </div>
  );
}