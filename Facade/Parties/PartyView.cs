using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Facade.Parties;
public sealed class PartyView : EntityView 
{
    [DisplayName("Name")][Required] public string? Name { get; set; }
}