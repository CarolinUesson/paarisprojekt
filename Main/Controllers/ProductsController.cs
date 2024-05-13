using Data.Pd;

namespace Main.Controllers;
public class ProductsController(ProductFeatureDbContext c) : BaseController<ProductData>(c, c.Product)
{
}
