using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade;
    internal class ProductView : EntityView {

    [Required] public string? Name { get; set;}
}
