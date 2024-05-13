using Data.Pd;
using Domain.Repos;

namespace Main.Controllers;
public class ProductFeaturesController(ProductFeatureDbContext c, IProductFeaturesRepo r) : 
    BaseController<ProductFeatureData>(c, c.ProductFeature, r)
{
}
