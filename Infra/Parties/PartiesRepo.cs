using Data.Parties;
using Domain.Parties;
using Domain.Repos.Parties;
using Infra.Common;

namespace Infra.Parties;
public class PartiesRepo(PartyDbContext c) : Repo<Party, PartyData>(c, c.Party), IPartyRepo
{
    protected override IQueryable<PartyData> addFilter(IQueryable<PartyData> sql) => 
        string.IsNullOrEmpty(SearchString)
        ? sql
        : sql.Where(s => s.Name != null && s.Name.Contains(SearchString));

    protected override Party toEntity(PartyData? d) => new(d);
}
