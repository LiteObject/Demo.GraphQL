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
     * - Annotation-based or Pure Code-First (following example):
     *   In this approach, we don't bother about GraphQL schema types, we will just 
     *   write clean C# code that automatically translates to GraphQL types.
     * - Code-first
     *   In this approach, we use Schema types, Schema types allow us to keep the GraphQL 
     *   type configuration separate from our .NET types. This can be the right approach 
     *   when we do not want any Hot Chocolate attributes on our business objects.
     * - Schema-first
     ***************************************************************************************/
    public class Query
    {
        /* To lean more about DbContext injection:
         * https://chillicream.com/docs/hotchocolate/integrations/entity-framework 
         */
        public async Task<List<City>> GetCities(CityWeatherDbContext context) => await context.Cities.ToListAsync();

        public async Task<City?> GetCity(CityWeatherDbContext context, string name) => await context.Cities.Include(c => c.WeatherForecasts).FirstOrDefaultAsync(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }
}
