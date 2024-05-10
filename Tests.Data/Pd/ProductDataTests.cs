using Data;
using Data.Pd;
using Tests.Aids;

namespace Tests.Data.Pd;
[TestClass]public class ProductDataTests : SealedNewTests<ProductData, EntityData>
{
    [TestMethod] public void NameTest() => propertyTest();
}
