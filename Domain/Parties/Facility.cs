using Data.Parties;

namespace Domain.Parties;
public sealed class Facility(FacilityData? d) : Entity<FacilityData>(d)
{
    public string? Location => data.Location;
}
