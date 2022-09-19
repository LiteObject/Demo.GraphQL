namespace Demo.Weather.HotChocolate.GraphQL.GraphQL
{
    public class Query
    {
        // TO-DO: Inject dbcontext to get records
        readonly List<City> _cities = new(){
            new City { Id = 1, Name= "Fargo", WeatherForecasts = new List<WeatherForecast>()},
            new City { Id = 2, Name= "Frisco", WeatherForecasts = new List<WeatherForecast>()}
        };

        public List<City> GetCities() => _cities;

        public City? GetCity(string name) => _cities.FirstOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }
}
