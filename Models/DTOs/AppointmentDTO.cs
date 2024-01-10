using System.ComponentModel.DataAnnotations;


namespace Salon.Models.DTOs;

public class AppointmentDTO
{
    public int Id { get; set; }
    
    public int StylistId { get; set; }
    public StylistDTO Stylist { get; set; }
    public int CustomerId { get; set; }
    public CustomerDTO Customer { get; set; }
    
    public DateTime? AppointmentTime { get; set; }
    public List<AppointmentServiceDTO> Services { get; set; }
     public decimal? AppointmentPrice
    {
        get
        {
            if (Services != null && Services.Any())
            {
                // Calculate the total price by summing the prices of all services
                decimal totalPrice = Services.Sum(service => service.Service.Price);
                return totalPrice;
            }
            else
            {
                return null;
            }
        }
    }
   
}