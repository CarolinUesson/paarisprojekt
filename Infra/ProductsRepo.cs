using Data.Pd;
using Domain.Repos;
using Infra.Common;

namespace Infra;
public class ProductsRepo : Repo<ProductData>, IProductsRepo
{
}
