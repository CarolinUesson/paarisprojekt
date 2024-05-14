using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Facade.Pd;
public sealed class ProductView : EntityView
{

    [DisplayName("Name")][Required] public string? Name { get; set; }
}
