using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public abstract class Date<TDate>(TDate? d) : Entity<TDate>(d) where TDate : DateData, new()
    {
        [Required]
        public DateTime FromDate => data.FromDate;
        public DateTime? ThruDate => data.ThruDate;
    }
}
