using Data.Pd;

namespace Domain.Pd;
public sealed class Deployment(DeploymentData? d): Entity<DeploymentData>(d) {
    public DateTime FromDate => data.FromDate;
    public DateTime? ThruDate => data.ThruDate;
}