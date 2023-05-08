using Microsoft.AspNetCore.Mvc;
using QLCC.Services;
using QLCC.Services.Dtos.User;

namespace QLCC.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly UserServices _userServices;
    public WeatherForecastController(ILogger<WeatherForecastController> logger, UserServices userServices)
    {
        _logger = logger;
        _userServices = userServices;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
    [HttpGet("list-user")]
    public async Task<IActionResult> GetAction([FromQuery]UserGridPagingDto pagingDto)
    {
        var model = await _userServices.GetUsers(pagingDto);
        return Ok(model);
    }
}

