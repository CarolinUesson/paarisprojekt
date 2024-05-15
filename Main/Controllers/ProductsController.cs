using Aids.Methods;
using Data.Pd;
using Domain.Pd;
using Domain.Repos;
using Facade.Pd;

namespace Main.Controllers;
public class ProductsController(IProductsRepo r) :
    BaseController<Product, ProductView>(r)
{
    protected override Product toModel(ProductView v) =>
        new Product(Copy.Members<ProductView, ProductData>(v));
}
