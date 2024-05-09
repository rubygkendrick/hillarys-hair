using System.ComponentModel.DataAnnotations;

namespace HillarysHair.Models;

public class Appointment
{
    public int Id { get; set; }
    [Required]
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    
    [Required]
    public int StylistId { get; set; }
    public Stylist Stylist { get; set; }
    public DateTime Time { get; set; }
    public decimal TotalCost { get; set; }
    public List<AppointmentService> AppointmentServices { get; set; }
}