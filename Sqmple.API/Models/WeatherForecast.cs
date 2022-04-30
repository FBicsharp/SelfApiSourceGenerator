using SelfApiSourceGenerator.Attributes;


namespace sample.API.Models
{
    [GenerateApi(Version = 1.0)]
    [ExposeEndpoint(Get = true, GetByKey = true, Post = true, Put = true, DeleteByKey = false)]

    public class WeatherForecast
    {
        [isKeyFieldApi]
        public DateTime Date { get; set; }

        [isKeyFieldApi]
        public int TemperatureC { get; set; }

        [UpdateableFieldApi]
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
}