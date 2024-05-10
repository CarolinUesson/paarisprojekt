using Data.Pd;

namespace Domain.Pd
{
    public sealed class ProductFeature(ProductFeatureData d) : Entity<ProductFeatureData>(d)
    {
        public string? Description => data.Description;
    }
}
