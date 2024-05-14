using Data.Pd;
using Domain.Repos;
using Facade.Pd;

namespace Main.Controllers;
public class ProductsController(IProductsRepo r) :
    BaseController<ProductData, ProductView>(r)
{
}
