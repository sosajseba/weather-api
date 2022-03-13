namespace Api.Dtos;

public class WeatherDto
{
    public string? City { get; set; }
    public DateTime Date { get; set; }
    public string? Condition { get; set; }
    public decimal TempC { get; set; }
    public decimal TempF { get; set; }
    public byte Humidity { get; set; }
    public decimal Wind { get; set; }
    public byte RainChance { get; set; }
}