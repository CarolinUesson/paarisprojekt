using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Facade.Pd;
public class ProductView : EntityView
{

    [DisplayName("Description")][Required] public string? Name { get; set; }
}
