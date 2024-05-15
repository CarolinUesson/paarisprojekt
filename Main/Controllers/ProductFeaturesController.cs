using Aids.Methods;
using Data.Pd;
using Domain;
using Domain.Repos;
using Facade.Pd;

namespace Main.Controllers;
public class ProductFeaturesController(IProductFeaturesRepo r) :
    BaseController<ProductFeature, ProductFeatureView>(r)
{
    protected override ProductFeature toModel(ProductFeatureView v) => 
        new ProductFeature(Copy.Members<ProductFeatureView, ProductFeatureData>(v));
}
