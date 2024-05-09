
namespace HillarysHair.Models.DTOS;

public class AppointmentDTO
{
    public int Id { get; set; }

    public int CustomerId { get; set; }
    public CustomerDTO Customer { get; set; }
    public int StylistId { get; set; }
    public StylistDTO Stylist { get; set; }

    public DateTime Time { get; set; }
    public decimal TotalCost { get; set; }
    public List<AppointmentServiceDTO> AppointmentServices { get; set; }
     public List<ServiceDTO> Services { get; set; }
}