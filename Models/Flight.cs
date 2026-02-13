using System.ComponentModel.DataAnnotations;

namespace FlightBase.Models;

public class Flight
{
    public int Id { get; set; }

    [Required]
    [StringLength(4, MinimumLength = 2)]
    [Display(Name = "ICAO Airline Code")]
    public string IcaoAirlineCode { get; set; } = string.Empty;

    [Required]
    [StringLength(3, MinimumLength = 2)]
    [Display(Name = "IATA Airline Code")]
    public string IataAirlineCode { get; set; } = string.Empty;

    [Required]
    [StringLength(4, MinimumLength = 3)]
    [Display(Name = "ICAO Aircraft Type")]
    public string IcaoAircraftType { get; set; } = string.Empty;

    [Required]
    [StringLength(10, MinimumLength = 1)]
    [Display(Name = "Flight Number")]
    public string FlightNumber { get; set; } = string.Empty;

    [Required]
    [StringLength(4, MinimumLength = 4)]
    [Display(Name = "Origin ICAO")]
    public string OriginIcao { get; set; } = string.Empty;

    [Required]
    [StringLength(3, MinimumLength = 3)]
    [Display(Name = "Origin IATA")]
    public string OriginIata { get; set; } = string.Empty;

    [Required]
    [StringLength(4, MinimumLength = 4)]
    [Display(Name = "Destination ICAO")]
    public string DestinationIcao { get; set; } = string.Empty;

    [Required]
    [StringLength(3, MinimumLength = 3)]
    [Display(Name = "Destination IATA")]
    public string DestinationIata { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Duration")]
    public TimeSpan Duration { get; set; }

    [Display(Name = "Currently Operated")]
    public bool IsCurrentlyOperated { get; set; } = true;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
