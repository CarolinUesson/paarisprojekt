using Data.Pd;

namespace Domain
{
    public sealed class ProductFeature(ProductFeatureData d) : Entity<ProductFeatureData>(d)
    {
        public string? Description => data.Description;
    }
}
