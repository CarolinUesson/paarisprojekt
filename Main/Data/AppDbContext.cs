using Microsoft.EntityFrameworkCore;
using Infra.Pd;
using Infra.Parties;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder b)
    {
        base.OnModelCreating(b);
        DepDbContext.initializeTables(b);
        PartyDbContext.initializeTables(b);
    }
}
