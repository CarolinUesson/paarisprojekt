using Data.Pd;
using Domain.Repos;
using Facade.Pd;

namespace Main.Controllers;
public class ProductsController(IProductsRepo r) :
    BaseController<ProductData, ProductView>(r)
{
    protected override ProductData toModel(ProductView v) => new()
        {
            Id = v.Id,
            Name = v.Name
        };

    protected override ProductView toView(ProductData m) => new()
        {
            Id = m.Id,
            Name = m.Name
        };
}
