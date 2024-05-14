using Data.Pd;
using Domain.Repos;
using Infra.Common;

namespace Infra;
public class ProductsRepo(DepDbContext c) :
    Repo<ProductData>(c, c.Product), IProductsRepo
{
    protected override IQueryable<ProductData> addFilter(IQueryable<ProductData> sql) =>
        string.IsNullOrEmpty(SearchString)
        ? sql
        : sql.Where(s => s.Name != null && s.Name.Contains(SearchString));
}
