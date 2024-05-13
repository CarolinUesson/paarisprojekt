using Data.Pd;
using Domain.Repos;
using Infra.Common;

namespace Main.Data;
public class ProductsRepo(ProductFeatureDbContext c) :
    Repo<ProductData>(c, c.Product), IProductsRepo
{
}
