//using Microsoft.AspNetCore.Mvc;

//namespace sample.API.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    [ApiVersion("1.0")]
//    [non]
//    public class Weather1ForecastController : ControllerBase
//    {
//        private static readonly string[] Summaries = new[]
//        {
//        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//    };

//        private readonly ILogger<Weather1ForecastController> _logger;

//        public Weather1ForecastController(ILogger<Weather1ForecastController> logger)
//        {
//            _logger = logger;
//        }

//        [HttpGet]
//        [Route("GetWeatherForecast1")]
//        public IEnumerable<WeatherForecast> Get()
//        {
//            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
//            {
//                Date = DateTime.Now.AddDays(index),
//                TemperatureC = Random.Shared.Next(-20, 55),
//                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
//            })
//            .ToArray();
//        }

        
//        //[HttpGet]
//        //public WeatherForecast Getaaaa()
//        //{
//        //    return new WeatherForecast
//        //    {
//        //        Date = DateTime.Now.AddDays(1),
//        //        TemperatureC = Random.Shared.Next(-20, 55),
//        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
//        //    };        }
        



//    }
//}