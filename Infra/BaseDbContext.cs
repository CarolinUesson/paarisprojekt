using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra;
public abstract class BaseDbContext<TDbContext>(DbContextOptions<TDbContext> o) : 
    DbContext(o) where TDbContext : DbContext
{
    protected static EntityTypeBuilder<TEntity> toTable<TEntity>(ModelBuilder b, string name, string schema) where TEntity : class
    {
        return b.Entity<TEntity>().ToTable(name, schema);
    }
}
