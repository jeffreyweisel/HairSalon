import { useState } from "react";
import { Button, Form, FormGroup, Input, Label } from "reactstrap";
import { useNavigate } from "react-router-dom/dist";
import { addCustomer } from "../../data/customerData";

export default function AddCustomerForm() {
  const navigate = useNavigate();

  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState("");
  const [email, setEmail] = useState("");
  const [address, setAddress] = useState("");
  

  const submit = () => {
    const newCustomer = {
      firstName,
      lastName,
      email,
      address
    };

    addCustomer(newCustomer).then(() => {
      navigate("/customers");
    });
  };

  return (
    <div className="container">
      <h4>Add New Customer</h4>
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