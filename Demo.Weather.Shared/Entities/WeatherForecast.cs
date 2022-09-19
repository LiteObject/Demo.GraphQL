using System.Text.Json.Serialization;

namespace Demo.Weather.Shared.Entities
{
    public class WeatherForecast
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int TemperatureC => 5 / 9 * (TemperatureF - 32);

        public int TemperatureF { get; set; }

        public string? Summary { get; set; }

        public int CityId { get; set; }

        [JsonIgnore]
        public virtual City? City { get; set; }
    }
}