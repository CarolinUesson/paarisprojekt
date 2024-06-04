using Data.Parties;
using Microsoft.EntityFrameworkCore;

namespace Infra.Parties.Init;
public sealed class FacilityDbInitializer(DbContext c, DbSet<FacilityData> s) : DbInitializer<FacilityData>(c, s)
{
    protected override void setValues(int idx)
    {
        if (item == null) return;
        item.Location = $"Facility {idx}";
    }
}