using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Api.Dtos;

namespace Api.Entities;

public class Weather : Base
{
    [Required]
    public int CityId { get; set; }
    public City? City { get; set; }
    [Required]
    public DateTime Date { get; set; }
    [Required]
    public Condition Condition { get; set; }
    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal TempC { get; set; }
    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal TempF { get; set; }
    [Required]
    public byte Humidity { get; set; }
    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Wind { get; set; }
    [Required]
    public byte RainChance { get; set; }

    public WeatherDto ToDto()
    {
        return new WeatherDto
        {
            City = City != null ? City.Name : string.Empty,
            Date = Date,
            Humidity = Humidity,
            RainChance = RainChance,
            Wind = Wind,
            Condition = Condition.ToString(),
            TempC = TempC,
            TempF = TempF
        };
    }

    public WeatherDto ToForecastDto()
    {
        return new WeatherDto
        {
            Date = Date,
            Condition = Condition.ToString(),
            TempC = TempC,
            TempF = TempF
        };
    }
}

public enum Condition
{
    Sunny,
    PartlyCloudy,
    Cloudy,
    Rain,
    Storm,
    Snow
}