using Data.Pd;
using Domain.Pd;
using Domain.Repos;
using Infra.Common;

namespace Infra.Pd;
public class ProductsRepo(DepDbContext c) :
    Repo<Product, ProductData>(c, c.Product), IProductsRepo
{
    protected override IQueryable<ProductData> addFilter(IQueryable<ProductData> sql) =>
        string.IsNullOrEmpty(SearchString)
        ? sql
        : sql.Where(s => s.Name != null && s.Name.Contains(SearchString));

    protected override Product toEntity(ProductData? d) => new(d);
}
