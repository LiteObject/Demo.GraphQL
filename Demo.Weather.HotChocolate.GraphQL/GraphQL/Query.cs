using Demo.Weather.Shared.Database;
using Demo.Weather.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo.Weather.HotChocolate.GraphQL.GraphQL
{
    /***************************************************************************************
     * The query type in GraphQL represents a read-only view of all of our entities 
     * and ways to retrieve them. A query type is required for every GraphQL server.
     * 
     * A query type can be defined in three ways:
     * - Annotation-based (following example)
     * - Code-first
     * - Schema-first
     ***************************************************************************************/
    public class Query
    {
        // TO-DO: Inject dbcontext to get records
        readonly List<City> _cities = new(){
            new City { Id = 1, Name= "Fargo", WeatherForecasts = new List<WeatherForecast>()},
            new City { Id = 2, Name= "Frisco", WeatherForecasts = new List<WeatherForecast>()}
        };

        /* To lean more about DbContext injection:
         * https://chillicream.com/docs/hotchocolate/integrations/entity-framework 
         */
        public async Task<List<City>> GetCities(CityWeatherDbContext context) => await context.Cities.ToListAsync();

        public async Task<City?> GetCity(CityWeatherDbContext context, string name) => await context.Cities.Include(c => c.WeatherForecasts).FirstOrDefaultAsync(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }
}
