using Data.Pd;

namespace Domain.Pd
{
    public sealed class Product(ProductData d) : Entity<ProductData>(d)
    {
        public string? Name => data.Name;
    }
}
