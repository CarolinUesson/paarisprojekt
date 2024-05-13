using Data.Pd;
using Domain.Repos;
using Infra.Common;

namespace Main.Data;
public class ProductFeaturesRepo(AppDbContext c) :
    Repo<ProductFeatureData>(c, c.ProductFeature), IProductFeaturesRepo
{
}
