using Microsoft.AspNetCore.Mvc;
using WeatherApi.Services;

[ApiController]
[Route("api/[controller]")]
public class WeatherController : ControllerBase
{
    private readonly IWeatherService _weatherService;

    public WeatherController(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] string city)
    {
        if (string.IsNullOrWhiteSpace(city))
            return BadRequest("City parameter is required.");

        var weather = await _weatherService.GetWeatherAsync(city);
        if (weather == null)
            return NotFound($"Weather data for '{city}' not found.");

        return Ok(weather);
    }
}
