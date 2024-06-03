using Data.Parties;

namespace Domain.Parties;
public sealed class PartyFacility(PartyFacilityData? d) : Entity<PartyFacilityData>(d) 
{
    public string? PartyId => data.PartyId;
}