using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class WeatherController : ControllerBase
{
    private readonly WeatherService _weatherService;


    public WeatherController(WeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    [HttpGet]
    public async Task<ActionResult<CombinedWeatherResult>> GetWeather([FromQuery] string city)
    {
        var result = await _weatherService.GetWeather(city);
        if (result is null) return NotFound();
        return Ok(result);
    }
}
