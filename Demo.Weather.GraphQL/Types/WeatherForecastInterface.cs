using Demo.Weather.Shared.Entities;
using GraphQL.Types;

namespace Demo.Weather.GraphQL.Types
{
    public class WeatherForecastInterface : InterfaceGraphType<WeatherForecast>
    {
        public WeatherForecastInterface()
        {
            Name = "WeatherForecast";

            Field(d => d.Summary).Description("The weather forecast summary");
            Field(d => d.TemperatureC, nullable: false).Description("The temperature in celcius.");

            Field<ListGraphType<WeatherForecastInterface>>("MultiDayWeatherForecast");
            // Field<ListGraphType<EpisodeEnum>>("appearsIn", "Which movie they appear in.");
        }
    }
}
