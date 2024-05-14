using Data.Pd;
using Domain.Repos;
using Facade.Pd;

namespace Main.Controllers;
public class ProductFeaturesController(IProductFeaturesRepo r) :
    BaseController<ProductFeatureData, ProductFeatureView>(r)
{
    protected override ProductFeatureData toModel(ProductFeatureView v) => new()
        {
            Id = v.Id,
            Description = v.Description
        };
    

    protected override ProductFeatureView toView(ProductFeatureData m) => new()
        {
            Id = m.Id,
            Description = m.Description
        };
}
