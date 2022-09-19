using Demo.Weather.Shared.Entities;

namespace Demo.Weather.GraphQL
{
    public static class DataGenerator
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private static readonly City[] Cities = new[]
        {
            new City{ Id = 1, Name = "Fargo" },
            new City{ Id = 2, Name = "Frisco" },
            new City{ Id = 3, Name = "Fairfield" },
            new City{ Id = 4, Name = "Fort Worth" },
            new City{ Id = 5, Name = "Flagstaff" },
            new City{ Id = 6, Name = "Flower Mound" },
            new City{ Id = 7, Name = "Frankfort" },
        };

        // Generate random data for seeding purpose
        public static IEnumerable<WeatherForecast> GetWeatherForecasts(int count = 100)
        {
            List<WeatherForecast> weatherForecasts = new();
            weatherForecasts.AddRange(
              Enumerable.Range(1, count).Select(index => new WeatherForecast
              {
                  Id = index,
                  Date = DateTime.Now.AddDays(index),
                  TemperatureF = Random.Shared.Next(1, 110),
                  Summary = Summaries[Random.Shared.Next(Summaries.Length)],
                  CityId = Cities[Random.Shared.Next(Cities.Length)].Id
              }).ToArray()
           );

            return weatherForecasts;
        }

        public static IEnumerable<City> GetCities()
        {
            return Cities;
        }
    }
}
