using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Facade.Pd;
public sealed class PriceComponentView: DateView {
    [DisplayName("Price")][Required] public decimal? Price { get; set; }
    [DisplayName("Type")][Required] public string? Type { get; set; }

}

