import { useState } from "react";
import { Button, Form, FormGroup, Input, Label } from "reactstrap";
import { useNavigate } from "react-router-dom/dist";
import { addStylist } from "../../data/stylistData";

export default function AddStylistForm() {
  const navigate = useNavigate();

  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState("");
  const [email, setEmail] = useState("");
  const [address, setAddress] = useState("");
  

  const submit = () => {
    const newStylist = {
      firstName,
      lastName,
      email,
      address
    };

    addStylist(newStylist).then(() => {
      navigate("/stylists");
    });
  };

  return (
    <div className="container">
      <h4>Add New Stylist</h4>
      <Form>
        <FormGroup>
          <Label htmlFor="firstName">First Name</Label>
          <Input
            type="text"
            placeholder="First Name"
            name="firstName"
            value={firstName}
            onChange={(e) => {
              setFirstName(e.target.value);
            }}
          />
        </FormGroup>
        <FormGroup>
          <Label htmlFor="lastName">Last Name</Label>
          <Input
            type="text"
            placeholder="Last Name"
            name="lastName"
            value={lastName}
            onChange={(e) => {
              setLastName(e.target.value);
            }}
          />
        </FormGroup>
        <FormGroup>
          <Label htmlFor="email">Email Address</Label>
          <Input
            type="text"
            placeholder="example@example.com"
            name="email"
            value={email}
            onChange={(e) => {
              setEmail(e.target.value);
            }}
          />
        </FormGroup>
        <FormGroup>
          <Label htmlFor="address">Home Address</Label>
          <Input
            type="text"
            placeholder="111 Example Street"
            name="address"
            value={address}
            onChange={(e) => {
              setAddress(e.target.value);
            }}
          />
        </FormGroup>
        <Button onClick={submit}>Submit</Button>
      </Form>
    </div>
  );
}