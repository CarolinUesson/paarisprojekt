using Data.Pd;
using Data;
using Tests.Aids;

namespace Tests.Data.Pd;
[TestClass] public class DeploymentDataTests : SealedNewTests<DeploymentData, EntityData>
{
    [TestMethod] public void FromDateTest() => propertyTest(); 
    [TestMethod] public void ThruDateTest() => propertyTest(); 
}
