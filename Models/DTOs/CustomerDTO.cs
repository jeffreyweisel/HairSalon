using System.ComponentModel.DataAnnotations;

namespace Salon.Models.DTOs;

public class CustomerDTO
{
    public int Id { get; set; }
   
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
   
    public string Email { get; set; }
   
    public string Address { get; set; }
    
    public List<Appointment> Appointments { get; set; }
}