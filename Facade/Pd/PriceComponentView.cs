using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Facade.Pd;
public sealed class PriceComponentView: EntityView {
    [DisplayName("FromDate")][Required] public DateTime FromDate { get; set; }
    [DisplayName("ThruDate")][Required] public DateTime ThruDate { get; set; }
    [DisplayName("Price")][Required] public decimal Price { get; set; }
    [DisplayName("Type")][Required] public string? Type { get; set; }

}

