using Data.Parties;
using Data.Pd;
using Microsoft.EntityFrameworkCore;

namespace Infra.Parties;
public class PartyDbContext(DbContextOptions<PartyDbContext> o) : BaseDbContext<PartyDbContext>(o)
{
    internal const string partySchema = "Party";
    public DbSet<PartyData> Party { get; set; } = default!;
    public DbSet<PartyFacilityData> PartyFacility { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder b)
    {
        base.OnModelCreating(b);
        initializeTables(b);
    }

    public static void initializeTables(ModelBuilder b)
    {
        toTable<PartyData>(b, nameof(Party), partySchema);
        toTable<PartyFacilityData>(b, nameof(PartyFacility), partySchema);
    }
}
