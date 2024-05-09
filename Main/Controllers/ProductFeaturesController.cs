using Data;

namespace Main.Controllers;
public class ProductFeaturesController(ProductFeatureDbContext c) : BaseController<ProductFeatureData>(c, c.ProductFeature)
{
}
