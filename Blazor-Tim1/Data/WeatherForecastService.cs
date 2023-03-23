using Microsoft.Extensions.Configuration;
namespace Blazor_Tim1.Data
{
    public class WeatherForecastService
    {

        // Inject a dependency into this class. Ask for the service from the constructor.
        // To add logging to a class, you basically do the same thing. Make a constructor...
        public WeatherForecastService(IConfiguration config, IDataAccess db, ILogger<WeatherForecastService> log)
        {
            _config = config;
            _db = db;
            _log = log;
        }
        private readonly IDataAccess _db;
        private readonly IConfiguration _config;
        private readonly ILogger<WeatherForecastService> _log;

        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            int upperValue = _db.GetUserAge();

            _log.LogInformation("Call GetForecastAsync(...). UpperValue={val}", upperValue);

            // Remember, models do not need interfaces as they can't really be replaced...
            //   so new WeatherForecast is new, instead of being injected.
            // return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            return Task.FromResult(Enumerable.Range(1, _db.GetUserAge()).Select(index => new WeatherForecast
           {
               Date = startDate.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToArray());
        }
    }
}