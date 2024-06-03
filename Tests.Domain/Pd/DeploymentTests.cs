using Data.Pd;
using Domain;
using Domain.Pd;

namespace Tests.Domain.Pd;
[TestClass] public class DeploymentTests : DomainClassTests<Deployment, DeploymentData>
{
    protected override Type baseType => typeof(Date<DeploymentData>);
}
