import { Navbar, NavbarBrand, Nav, NavItem, NavLink } from "reactstrap";
import "./App.css";
import "bootstrap/dist/css/bootstrap.css";
import { Outlet } from "react-router-dom";
function App() {
  return (
    <>
      <Navbar color="light" light expand="md" className="bg-info">
        <Nav navbar>
          <NavbarBrand href="/"> 💈✂️ Hillary's Hair Salon</NavbarBrand>
          <NavItem>
            <NavLink href="/stylists">Stylists</NavLink>
          </NavItem>
          <NavItem>
            <NavLink href="/customers">Customers</NavLink>
          </NavItem>
          <NavItem>
            <NavLink href="/appointments">Appointments</NavLink>
          </NavItem>
          <NavItem>
            <NavLink href="/services">Services</NavLink>
          </NavItem>
        </Nav>
      </Navbar>
      <Outlet />
    </>
  );
}

export default App;
