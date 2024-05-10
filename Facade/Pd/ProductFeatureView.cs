using System.ComponentModel.DataAnnotations;

namespace Facade.Pd
{
    internal class ProductFeatureView : EntityView
    {
        [Required] public string Description { get; set; }
    }
}
