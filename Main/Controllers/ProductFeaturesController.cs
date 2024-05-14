using Data.Pd;
using Domain.Repos;
using Facade.Pd;

namespace Main.Controllers;
public class ProductFeaturesController(IProductFeaturesRepo r) :
    BaseController<ProductFeatureData, ProductFeatureView>(r)
{
}
