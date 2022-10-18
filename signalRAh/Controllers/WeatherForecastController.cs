using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using signalRAh.Domain.Entities;
using signalRAh.Infrastructures;

namespace signalRAh.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    private ApplicationContext _context;
    private readonly IMediator _mediator;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, ApplicationContext context,
            IMediator _madiator)
    {
        _logger = logger;
        _context = context;
        _mediator = _madiator;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }



    [HttpPost("CreateGroupMessage")]
    public async Task<string> SendTheMessageSignalR(string input)
    {
        //var command = input.Adapt<CreateThreadMessageCommand>();
       var command = new CreateThreadMessageCommand(input);
        var result = await _mediator.Send<string>(command);
        return result;
    }





    [HttpGet("DatasFake")]
    public string InsertFakeDatas()
    {
        var data = new List<SickPersionEntity>();
        for (var i = 0; i < 100; i++)
        {

            var item = new SickPersionEntity($"name{i}", $"Id{i}", $"room{i}", $"staet{i}");

            data.Add(item);
        }
        _context.SickPersionEntity.AddRange(data);
        _context.SaveChanges();
        return "run";
    }




    [HttpGet("GetFromViews")]
    public IEnumerable<SickPersion> GetFromViews()
    {
        return _context.SickPersion.ToList();
    }
}
