using System.ComponentModel.DataAnnotations;

namespace Demo.Weather.Shared.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public Product(string name, decimal unitPrice)
        {
            ArgumentException.ThrowIfNullOrEmpty("name");

            this.Name = name;
            SetUnitPrice(unitPrice);
        }

        public string Name { get; set; } = string.Empty;

        public decimal UnitPrice { get; private set; }

        public void SetUnitPrice(decimal unitPrice)
        {
            if (unitPrice is <= 0 or > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(unitPrice), "Unit price must be between 1 and 100.");
            }

            UnitPrice = unitPrice;
        }
    }
}
