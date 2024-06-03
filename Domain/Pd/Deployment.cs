using Data.Pd;
using System.ComponentModel.DataAnnotations;

namespace Domain.Pd;
public sealed class Deployment(DeploymentData? d): Date<DeploymentData>(d) {
    
}