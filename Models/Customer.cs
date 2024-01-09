using System.ComponentModel.DataAnnotations;

namespace Salon.Models;

public class Customer
{
    public int Id { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Address { get; set; }
    [Required]
    public List<Appointment> Appointments { get; set; }
}