using Data.Pd;
using System.ComponentModel.DataAnnotations;

namespace Domain.Pd;
public sealed class Deployment(DeploymentData? d): Entity<DeploymentData>(d) {
    [Required]
    public DateTime FromDate => data.FromDate;
    public DateTime? ThruDate => data.ThruDate;
}