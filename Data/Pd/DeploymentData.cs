using System.ComponentModel.DataAnnotations;

namespace Data.Pd;
public sealed class DeploymentData: EntityData {
    [DataType(DataType.Date)] public DateTime FromDate { get; set; }
    [DataType(DataType.Date)] public DateTime? ThruDate { get; set; }
}