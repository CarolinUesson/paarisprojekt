using Data.Pd;
using Domain.Repos;
using Infra.Common;

namespace Infra.Pd;
public class ProductFeaturesRepo(DepDbContext c) :
    Repo<ProductFeatureData>(c, c.ProductFeature), IProductFeaturesRepo
{
    protected override IQueryable<ProductFeatureData> addFilter(IQueryable<ProductFeatureData> sql) =>
        string.IsNullOrEmpty(SearchString)
        ? sql
        : sql.Where(s => s.Description != null && s.Description.Contains(SearchString));
}
