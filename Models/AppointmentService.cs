using System.ComponentModel.DataAnnotations;

namespace Salon.Models;

public class AppointmentService
{
    public int Id { get; set; }

    [Required]
    public int AppointmentId { get; set; }  // Corrected property name

    public Appointment Appointment { get; set; }

    [Required]
    public int ServiceId { get; set; }
    public Service Service { get; set; }
}
