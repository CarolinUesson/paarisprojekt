using Data.Parties;

namespace Domain.Parties;
public sealed class Party(PartyData? d) : Entity<PartyData>(d) 
{
    public string? Name => data.Name;
}