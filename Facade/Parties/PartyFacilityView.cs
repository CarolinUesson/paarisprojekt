using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Facade.Parties;
[Description("Party")] public sealed class PartyFacilityView : EntityView 
{
    [DisplayName("Party")][Required] public int PartyId { get; set; }
    [DisplayName("Facility")][Required] public int FacilityId { get; set; }
}