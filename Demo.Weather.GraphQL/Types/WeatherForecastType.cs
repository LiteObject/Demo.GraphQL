using Demo.Weather.Shared.Entities;
using GraphQL.Types;

namespace Demo.Weather.GraphQL.Types
{
    public class WeatherForecastType : ObjectGraphType<WeatherForecast>
    {
        public WeatherForecastType()
        {

        }
    }
}
