using Microsoft.AspNetCore.Mvc;

namespace ASPJoke.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JokesController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public JokesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<ActionResult<string>> GetRandomJoke()
        {
            Console.WriteLine("Hier 1");
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://api.chucknorris.io/jokes/random"); // Replace with your actual joke API endpoint
            Console.WriteLine("Hier 2");
            if (response.IsSuccessStatusCode)
            {
                var joke = await response.Content.ReadAsStringAsync();
                return Ok(joke);
            }

            return StatusCode((int)response.StatusCode, "Failed to retrieve a joke");
        }
        //    private static readonly string[] Summaries = new[]
        //    {
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};

        //    private readonly ILogger<WeatherForecastController> _logger;

        //    public WeatherForecastController(ILogger<WeatherForecastController> logger)
        //    {
        //        _logger = logger;
        //    }

        //    [HttpGet]
        //    public IEnumerable<WeatherForecast> Get()
        //    {
        //        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //        {
        //            Date = DateTime.Now.AddDays(index),
        //            TemperatureC = Random.Shared.Next(-20, 55),
        //            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //        })
        //        .ToArray();
        //    }
    }
}