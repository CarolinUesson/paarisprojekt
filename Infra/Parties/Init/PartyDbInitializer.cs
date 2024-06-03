using Data.Parties;
using Microsoft.EntityFrameworkCore;

namespace Infra.Parties.Init;
public sealed class PartyDbInitializer(DbContext c, DbSet<PartyData> s) : DbInitializer<PartyData>(c, s)
{
    protected override void setValues(int idx)
    {
        if (item == null) return;
        item.Name = $"Party {idx}";
    }
}
