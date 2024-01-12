const apiUrl = "/api/services";

// Get services
export const getServices = () => {
  return fetch(apiUrl).then((r) => r.json());
};
