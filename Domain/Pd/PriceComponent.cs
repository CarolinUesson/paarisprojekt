using Data.Pd;
using System.ComponentModel.DataAnnotations;

namespace Domain.Pd;
public sealed class PriceComponent(PriceComponentData? d): Entity<PriceComponentData>(d) {
    [Required]
    public DateTime FromDate => data.FromDate;
    public DateTime? ThruDate => data.ThruDate;
    public decimal? Price => data.Price;
    public string? Type => data.Type;

}
