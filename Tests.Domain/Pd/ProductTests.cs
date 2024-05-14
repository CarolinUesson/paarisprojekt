using Aids.Methods;
using Data.Pd;
using Domain;
using Domain.Pd;
using Tests.Aids;

namespace Tests.Domain.Pd;
[TestClass] public class ProductTests : SealedTests<Product, Entity<ProductData>>
{
    private ProductData data;
    protected override Product? createObject()
    {
        data = GetRnd.Object<ProductData>();
        return new Product(data);
    }
    [TestMethod] public void NameTest() => Assert.AreEqual(data?.Name, obj?.Name);
}
