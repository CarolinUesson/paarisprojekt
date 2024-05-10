using System.ComponentModel.DataAnnotations;

namespace Facade.Pd;
internal class ProductView : EntityView
{

    [Required] public string? Name { get; set; }
}
