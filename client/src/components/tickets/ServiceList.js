import { useEffect, useState } from "react";
import { Card, CardBody, CardTitle, CardText } from "reactstrap";
import { getServices } from "../../data/servicesData";

export default function ServiceList() {
  const [services, setServices] = useState([]);

  useEffect(() => {
    getServices().then(setServices);
  }, []);

  return (
    <div className="container">
      <div className="sub-menu bg-light">
        <h4>Offered Services</h4>
      </div>
      {services.map((service) => (
        <Card key={`service-${service.id}`} className="mb-3">
          <CardBody>
            <CardTitle tag="h5">{service.name}</CardTitle>
            <CardText>
              <strong>Price:</strong> {service.price} <br />
            </CardText>
          </CardBody>
        </Card>
      ))}
    </div>
  );
}
