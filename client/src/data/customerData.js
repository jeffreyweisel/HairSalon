const apiUrl = "/api/customers"

// Get customers
export const getCustomers = () => {
    return fetch(apiUrl).then((r) => r.json());
  };

// Get customer by Id
export const getCustomer = (id) => {
    return fetch(`${apiUrl}/${id}`).then((r) => r.json());
  };

// Add new customer to the system
export const addCustomer = (stylist) => {
    return fetch(apiUrl, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(stylist),
    }).then((res) => res.json());
  };