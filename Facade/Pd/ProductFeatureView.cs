using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Facade.Pd
{
    public sealed class ProductFeatureView : EntityView
    {
        [DisplayName("Description")][Required] public string? Description { get; set; }
    }
}
