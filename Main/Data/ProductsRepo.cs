using Data.Pd;
using Domain.Repos;
using Infra.Common;

namespace Main.Data;
public class ProductsRepo(AppDbContext c) :
    Repo<ProductData>(c, c.Product), IProductsRepo
{
    protected override IQueryable<ProductData> addFilter(IQueryable<ProductData> sql) =>
        string.IsNullOrEmpty(SearchString) 
        ? sql 
        : sql.Where(s => (s.Name != null) && s.Name.Contains(SearchString));
}
