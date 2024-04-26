using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Main.Models;
using Data;

public class ProductFeatureDbContext : DbContext
    {
        public ProductFeatureDbContext (DbContextOptions<ProductFeatureDbContext> options)
            : base(options)
        {
        }

        public DbSet<ProductFeatureData> ProductFeature { get; set; } = default!;
    }
