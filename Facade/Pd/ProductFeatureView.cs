using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Facade.Pd
{
    public sealed class ProductFeatureView : EntityView
    {
        //[Required] public string Description { get; set; }
        [DisplayName("Description")][Required] public string? Description { get; set; }
    }
}
