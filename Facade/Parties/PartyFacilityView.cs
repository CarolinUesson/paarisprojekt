using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Facade.Parties;
public sealed class PartyFacilityView : EntityView 
{
    [DisplayName("Party")][Required] public string? PartyId { get; set; }
}