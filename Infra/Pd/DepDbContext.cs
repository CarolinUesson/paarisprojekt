using Data.Pd;
using Microsoft.EntityFrameworkCore;

namespace Infra.Pd;
public class DepDbContext(DbContextOptions<DepDbContext> o) :
    BaseDbContext<DepDbContext>(o)
{
    internal const string depSchema = "Dep";
    public DbSet<ProductFeatureData> ProductFeature { get; set; } = default!;
    public DbSet<ProductData> Product { get; set; } = default!;
    public DbSet<PriceComponentData> PriceComponent { get; set; } = default!;
    protected override void OnModelCreating(ModelBuilder b)
    {
        base.OnModelCreating(b);
        initializeTables(b);
    }

    public static void initializeTables(ModelBuilder b)
    {
        toTable<ProductFeatureData>(b, nameof(ProductFeature), depSchema);
        toTable<ProductData>(b, nameof(Product), depSchema);
        toTable<PriceComponentData>(b, nameof(PriceComponent), depSchema);
    }
}
