using Data.Pd;
using Microsoft.EntityFrameworkCore;

namespace Infra;
public class DepDbContext(DbContextOptions<DepDbContext> o) : 
    BaseDbContext<DepDbContext>(o)
{
    public DbSet<ProductFeatureData> ProductFeature { get; set; } = default!;
    public DbSet<ProductData> Product { get; set; } = default!;
}
