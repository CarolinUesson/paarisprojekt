using Microsoft.EntityFrameworkCore;
using Infra;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder b)
    {
        base.OnModelCreating(b);
        DepDbContext.initializeTables(b);
    }
}
