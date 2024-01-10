import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import StylistList from './components/tickets/StylistList';
import StylistDetails from './components/tickets/StylistDetails';
import CustomerList from './components/tickets/CustomerList';
import CustomerDetails from './components/tickets/CustomerDetails';
import AppointmentList from './components/tickets/AppointmentList';
import ServiceList from './components/tickets/ServiceList';
import AddStylistForm from './components/tickets/AddStylistForm';
import AddCustomerForm from './components/tickets/AddCustomerForm';

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(
  <BrowserRouter>
    <Routes>
      <Route path="/" element={<App />}>
        <Route path="stylists">
          <Route index element={<StylistList />} />
          <Route path=":id" element={<StylistDetails />} />
          <Route path='create' element={< AddStylistForm />} />
        </Route>
        <Route path="customers">
          <Route index element={<CustomerList />} />
          <Route path=":id" element={<CustomerDetails />} />
          <Route path="create" element={< AddCustomerForm />} />
        </Route>
        <Route path="appointments">
          <Route index element={<AppointmentList />} />
          
        </Route>
        <Route path="services">
          <Route index element={<ServiceList />} />
          
        </Route>
      </Route>
    </Routes>
  </BrowserRouter>
);


// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
