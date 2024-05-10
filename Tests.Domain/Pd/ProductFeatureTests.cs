using Aids.Methods;
using Data;
using Data.Pd;
using Domain;
using Domain.Pd;
using Tests.Aids;

namespace Tests.Domain;
[TestClass]
public class ProductFeatureTests : SealedTests<ProductFeature, Entity<ProductFeatureData>>
{
    private ProductFeatureData data;
    protected override ProductFeature? createObject()
    {
        data = GetRnd.Object<ProductFeatureData>();
        return new ProductFeature(data);
    }
    [TestMethod] public void DescriptionTest() => Assert.AreEqual(data?.Description, obj?.Description);
}
