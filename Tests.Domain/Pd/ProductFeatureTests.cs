using Data;
using Data.Pd;
using Domain;
using Domain.Pd;
using Tests.Aids;

namespace Tests.Domain;
[TestClass]
public class ProductFeatureTests : SealedTests<ProductFeatureData, EntityData>
{
    [TestMethod] public void DescriptionTest() => propertyTest();
}
