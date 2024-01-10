const apiUrl = "/api/stylists"

// Get stylists
export const getStylists = () => {
    return fetch(apiUrl).then((r) => r.json());
  };

// Get stylist by Id
export const getStylist = (id) => {
    return fetch(`${apiUrl}/${id}`).then((r) => r.json());
  };

//Deactivate stylist 
export const deactivateStylist = (id) => {
    return fetch(`${apiUrl}/deactivate/${id}`, {
      method: "PUT",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({}), // send empty object 
    }).then((r) => r.json());
  };

// Add new stylist to the system
export const addStylist = (stylist) => {
    return fetch(apiUrl, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(stylist),
    }).then((res) => res.json());
  };