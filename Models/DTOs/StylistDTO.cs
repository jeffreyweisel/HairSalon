using System.ComponentModel.DataAnnotations;

namespace Salon.Models.DTOs;

public class StylistDTO
{
    public int Id { get; set; }
   
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
   
    public string Email { get; set; }
    
    public string Address { get; set; }
    
    public bool IsActive { get; set; }
    public List<AppointmentDTO> Appointments { get; set; }
}