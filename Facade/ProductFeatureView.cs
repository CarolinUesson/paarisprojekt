using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    internal class ProductFeatureView : EntityView
    {
        [Required] public string Description { get; set; }
    }
}
