using Data.Pd;
using Domain.Repos;

namespace Main.Controllers;
public class ProductsController(IProductsRepo r) : BaseController<ProductData>(r)
{
}
