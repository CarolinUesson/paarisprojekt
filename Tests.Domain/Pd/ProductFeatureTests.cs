using Data.Pd;
using Domain;
using Tests.Domain.Pd;

namespace Tests.Domain;
[TestClass]
public class ProductFeatureTests : DomainClassTests<ProductFeature, ProductFeatureData>
{
    [TestMethod] public void DescriptionTest() => valueTest();
}
