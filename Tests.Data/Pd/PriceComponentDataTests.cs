using Tests.Aids;

namespace Data.Pd;
[TestClass] public class PriceComponentDataTests : SealedNewTests<PriceComponentData, EntityData>
{
    [TestMethod] public void FromDateTest() => propertyTest();
    [TestMethod] public void ThruDateTest() => propertyTest();
    [TestMethod] public void PriceTest() => propertyTest();
    [TestMethod] public void TypeTest() => propertyTest();
}
