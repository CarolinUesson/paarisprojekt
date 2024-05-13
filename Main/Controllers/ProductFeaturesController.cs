using Data.Pd;
using Domain.Repos;

namespace Main.Controllers;
public class ProductFeaturesController(IProductFeaturesRepo r) : BaseController<ProductFeatureData>(r)
{
}
