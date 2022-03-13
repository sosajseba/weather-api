using Microsoft.AspNetCore.Mvc;
using Api.Interfaces;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CountryController : ControllerBase
{
    private readonly ICountryService _countryService;
    public CountryController(ICountryService countryService)
    {
        _countryService = countryService;
    }

    [HttpGet]
    public IActionResult Get(int page, int size)
    {
        try
        {
            var response = _countryService.GetAll(page, size);
            return response.Succeeded ? Ok(response) : BadRequest(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}