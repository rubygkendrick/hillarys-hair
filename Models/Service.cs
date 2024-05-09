using System.ComponentModel.DataAnnotations;

namespace HillarysHair.Models;

public class Service
{
    public int Id { get; set; }
    [Required]
    public string Type { get; set; }
    public decimal Cost { get; set; }

}