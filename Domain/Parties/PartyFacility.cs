using Data.Parties;
using Domain.Repos.Parties;

namespace Domain.Parties;
public sealed class PartyFacility(PartyFacilityData? d) : Entity<PartyFacilityData>(d) 
{
    public async override Task LazyLoad()
    {
        await base.LazyLoad();
        if (Party != null || Facility != null) return;
        Party = await GetFromRepo.Item<IPartyRepo, Party>(PartyId);
        Facility = await GetFromRepo.Item<IFacilityRepo, Facility>(FacilityId);
    }
    public int PartyId => data.PartyId;
    public Party? Party {  get; private set; }
    public int FacilityId => data.FacilityId;
    public Facility? Facility { get; private set; }
}
