using Data.Pd;
using Microsoft.EntityFrameworkCore;

namespace Infra;
public class DepDbContext(DbContextOptions<DepDbContext> o) : 
    BaseDbContext<DepDbContext>(o)
{
    public DbSet<ProductFeatureData> ProductFeature { get; set; } = default!;
    public DbSet<ProductData> Product { get; set; } = default!;
    protected override void OnModelCreating(ModelBuilder b)
    {
        base.OnModelCreating(b);
        initializeTables(b); 
    }

    public static void initializeTables(ModelBuilder b)
    {
        b.Entity<ProductFeatureData>().ToTable(nameof(ProductFeature));
        b.Entity<ProductData>().ToTable(nameof(Product));
    }
}
