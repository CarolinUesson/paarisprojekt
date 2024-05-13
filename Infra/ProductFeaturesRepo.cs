using Data.Pd;
using Domain.Repos;
using Infra.Common;
using Microsoft.EntityFrameworkCore;

namespace Infra;
public class ProductFeaturesRepo(DbContext c, DbSet<ProductFeatureData> s) : 
    Repo<ProductFeatureData>(c, s), IProductFeaturesRepo
{
}
