using Demo.Weather.Shared.Entities;
using GraphQL.Types;

namespace Demo.Weather.GraphQL.Types
{
    public class ProductInterface : InterfaceGraphType<Product>
    {
        public ProductInterface()
        {
            Name = "Product";

            Field(d => d.Name).Description("Product Name");
            Field(d => d.UnitPrice, nullable: false).Description("Product Price");

            Field<ListGraphType<ProductInterface>>("MultiDayWeatherForecast");
            // Field<ListGraphType<EpisodeEnum>>("appearsIn", "Which movie they appear in.");
        }
    }
}
