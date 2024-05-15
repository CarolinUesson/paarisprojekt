using Data.Pd;
using Domain;
using Domain.Repos;
using Infra.Common;

namespace Infra.Pd;
public class ProductFeaturesRepo(DepDbContext c) :
    Repo<ProductFeature, ProductFeatureData>(c, c.ProductFeature), IProductFeaturesRepo
{
    protected override IQueryable<ProductFeatureData> addFilter(IQueryable<ProductFeatureData> sql) =>
        string.IsNullOrEmpty(SearchString)
        ? sql
        : sql.Where(s => s.Description != null && s.Description.Contains(SearchString));

    protected override ProductFeature toEntity(ProductFeatureData? d) => new(d);
}
