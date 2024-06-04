using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Facade.Parties;
public sealed class FacilityView : EntityView
{
    [DisplayName("Location")][Required] public string? Location { get; set; }
}