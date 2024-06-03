using Tests.Aids;

namespace Data.Pd;
[TestClass] public class PriceComponentDataTests : SealedNewTests<PriceComponentData, DateData>
{
    [TestMethod] public void PriceTest() => propertyTest();
    [TestMethod] public void TypeTest() => propertyTest();
}
