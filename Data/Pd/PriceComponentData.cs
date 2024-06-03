using System.ComponentModel.DataAnnotations;

namespace Data.Pd;
public sealed class PriceComponentData: DateData {
    
    
        public decimal? Price { get; set; }
        public string? Type { get; set; }

    }