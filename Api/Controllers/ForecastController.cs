using Microsoft.AspNetCore.Mvc;
using Api.Interfaces;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ForecastController : ControllerBase
{
    private readonly IWeatherService _weatherService;
    public ForecastController(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    [HttpGet]
    public IActionResult Get(int countryId, int cityId)
    {
        try
        {
            var response = _weatherService.GetForecast(countryId, cityId);
            return response.Succeeded ? Ok(response) : BadRequest(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}