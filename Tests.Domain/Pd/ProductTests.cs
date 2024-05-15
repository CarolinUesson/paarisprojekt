using Data.Pd;
using Domain.Pd;

namespace Tests.Domain.Pd;
[TestClass] public class ProductTests : DomainClassTests<Product, ProductData>
{
    [TestMethod] public void NameTest() => valueTest();
}
