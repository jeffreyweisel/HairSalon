using System.ComponentModel.DataAnnotations;

namespace Salon.Models.DTOs;

public class AppointmentServiceDTO
{
    public int Id { get; set; }
    public int AppoinmentId { get; set; }
    public AppointmentDTO Appointment { get; set; }
    public int ServiceId { get; set; }
    public ServiceDTO Service { get; set; }

}