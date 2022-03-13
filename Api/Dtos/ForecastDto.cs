namespace Api.Dtos;

public class ForecastDto
{
    public DateTime Date { get; set; }
    public string? Condition { get; set; }
    public decimal TempC { get; set; }
    public decimal TempF { get; set; }
}