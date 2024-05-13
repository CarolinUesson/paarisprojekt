using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Main.Models;
using Data.Pd;

public class ProductFeatureDbContext(DbContextOptions<ProductFeatureDbContext> options) : DbContext(options)
    {
    public DbSet<ProductFeatureData> ProductFeature { get; set; } = default!;
    public DbSet<ProductData> Product { get; set; } = default!;
}
