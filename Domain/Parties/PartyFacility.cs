using Data.Parties;

namespace Domain.Parties;
public sealed class PartyFacility(PartyFacilityData? d) : Entity<PartyFacilityData>(d) 
{
    public int PartyId => data.PartyId;
    public int FacilityId => data.FacilityId;
}