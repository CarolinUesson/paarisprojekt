using Microsoft.EntityFrameworkCore;
using Data.Pd;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
    public DbSet<ProductFeatureData> ProductFeature { get; set; } = default!;
    public DbSet<ProductData> Product { get; set; } = default!;
}
