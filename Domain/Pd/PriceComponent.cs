using Data.Pd;
using System.ComponentModel.DataAnnotations;

namespace Domain.Pd;
public sealed class PriceComponent(PriceComponentData? d): Date<PriceComponentData>(d) {
    
    public decimal? Price => data.Price;
    public string? Type => data.Type;

}
