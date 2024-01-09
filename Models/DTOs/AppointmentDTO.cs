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
    
    public int ServiceId { get; set; }
    public ServiceDTO Service { get; set; }
   
   
}