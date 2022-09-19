namespace Demo.Weather.Shared.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;

        public List<WeatherForecast> WeatherForecasts { get; set; } = new();
    }
}
