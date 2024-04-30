using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain {
    public sealed class Product(ProductData d): Entity<ProductData>(d) {
        public string? Name => data.Name;
    }
}
