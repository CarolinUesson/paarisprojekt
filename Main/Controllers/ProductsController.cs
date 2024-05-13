using Data.Pd;
using Domain.Repos;

namespace Main.Controllers;
public class ProductsController(AppDbContext c, IProductsRepo r) : 
    BaseController<ProductData>(c, c.Product, r)
{
}
