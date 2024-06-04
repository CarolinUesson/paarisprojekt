using Data.Parties;
using Domain.Parties;
using Domain.Repos.Parties;
using Infra.Common;

namespace Infra.Parties;
public class PartyFacilitiesRepo(PartyDbContext c) : Repo<PartyFacility, PartyFacilityData>(c, c.PartyFacility), IPartyFacilityRepo
{
    protected override IQueryable<PartyFacilityData> addFilter(IQueryable<PartyFacilityData> sql) =>
        string.IsNullOrEmpty(SearchString)
        ? sql
        : sql.Where(s => (s.PartyId != null && s.PartyId.ToString().Contains(SearchString))
        || s.FacilityId.ToString().Contains(SearchString));

    protected override PartyFacility toEntity(PartyFacilityData? d) => new(d);
}
