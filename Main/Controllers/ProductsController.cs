using Data.Pd;
using Domain.Repos;

namespace Main.Controllers;
public class ProductsController(ProductFeatureDbContext c, IProductsRepo r) : 
    BaseController<ProductData>(c, c.Product, r)
{
}
