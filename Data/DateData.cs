using System.ComponentModel.DataAnnotations;

namespace Data;
public abstract class DateData : EntityData
{
    [Required]
    [DataType(DataType.Date)] public DateTime FromDate { get; set; }

    [DataType(DataType.Date)] public DateTime? ThruDate { get; set; }
}
