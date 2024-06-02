using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Pd;
    public sealed class PriceComponentData: EntityData {
        [DataType(DataType.Date)] public DateTime FromDate { get; set; }
        [DataType(DataType.Date)] public DateTime ThruDate { get; set; }
        public decimal Price { get; set; }
        public string? Type { get; set; }

    }