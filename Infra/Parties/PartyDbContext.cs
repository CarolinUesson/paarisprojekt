using Data.Parties;
using Data.Pd;
using Microsoft.EntityFrameworkCore;

namespace Infra.Parties;
public class PartyDbContext(DbContextOptions<PartyDbContext> o) : BaseDbContext<PartyDbContext>(o)
{
    internal const string partySchema = "Party";
    public DbSet<PartyData> Party { get; set; } = default!;
    public DbSet<PartyFacilityData> PartyFacility { get; set; } = default!;
    public DbSet<FacilityData> Facility { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder b)
    {
        base.OnModelCreating(b);
        initializeTables(b);
    }

    public static void initializeTables(ModelBuilder b)
    {
        var schema = partySchema;
        toTable<PartyData>(b, nameof(Party), schema);
        toTable<FacilityData>(b, nameof(Facility), schema);
        var pf = toTable<PartyFacilityData>(b, nameof(PartyFacility), schema);
        pf.HasAlternateKey(nameof(PartyFacilityData.PartyId), nameof(PartyFacilityData.FacilityId));
    }
}
