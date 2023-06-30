using Demo.Weather.Shared.Entities;

namespace Demo.Weather.GraphQL
{
    public static class DataGenerator
    {
        public static Product[] GetProducts()
        {
            return new Product[]
            {
                  new Product("Apple", 1.1m) { Id = 1},
                    new Product("Orange", 2.2m) { Id = 2},
                    new Product("Mango", 3.3m) { Id = 3},
                    new Product("Avocado", 4.4m) { Id = 4}
            };
        }
    }
}

