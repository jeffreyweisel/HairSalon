import { useEffect, useState } from "react";
import { Button, Card, CardBody, CardText, CardTitle } from "reactstrap";
import { Link } from "react-router-dom";
import { deactivateStylist, getStylists } from "../../data/stylistData";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faBan } from "@fortawesome/free-solid-svg-icons";

export default function StylistList() {
  const [stylists, setStylists] = useState([]);

  useEffect(() => {
    getStylists().then(setStylists);
  }, []);

  const handleDeactivateButtonClick = async (id) => {
    console.log("Deactivating stylist with ID:", id);
    await deactivateStylist(id);
    const updatedStatus = await getStylists();
    setStylists(updatedStatus);
  };

  return (
    <div className="container">
      <div className="sub-menu bg-light d-flex">
        <div>
          <h4>Stylists</h4>
        </div>
        <Link to="/stylists/create" className="ml-2">
          Add
        </Link>
      </div>
      {stylists.map((stylist) => (
        <Card key={`stylist-${stylist.id}`} className="mb-3">
          <CardBody>
            <CardTitle tag="h5">
              {stylist.firstName} {stylist.lastName}{" "}
              <small className="text-muted">
                <Link to={`${stylist.id}`}>Details</Link>
              </small>
            </CardTitle>
            <CardText>
              <strong>Email:</strong> {stylist.email} <br />
              <strong>Address:</strong> {stylist.address} <br />
              <strong>Active:</strong> {stylist.isActive ? "Yes" : "No"} <br />
              {stylist.isActive && (
                <Button
                  size="sm"
                  color="secondary"
                  className="mt-2"
                  onClick={() => handleDeactivateButtonClick(stylist.id)}
                >
                  <FontAwesomeIcon icon={faBan} /> Deactivate
                </Button>
              )}
            </CardText>
          </CardBody>
        </Card>
      ))}
    </div>
  );
}
