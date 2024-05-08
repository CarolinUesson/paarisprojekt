using Data;

namespace Domain {
    public sealed class Product(ProductData d): Entity<ProductData>(d) {
        public string? Name => data.Name;
    }
}
