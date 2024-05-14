using Microsoft.EntityFrameworkCore;

namespace Infra;
public abstract class BaseDbContext<TDbContext>(DbContextOptions<TDbContext> o) : 
    DbContext(o) where TDbContext : DbContext
{
}
