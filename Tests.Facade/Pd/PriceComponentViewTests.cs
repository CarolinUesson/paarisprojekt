using Facade.Pd;
using Facade;
using Tests.Aids;

namespace Tests.Facade.Pd;
[TestClass] public class PriceComponentViewTests : SealedNewTests<PriceComponentView, DateView>
{
    [TestMethod] public void PriceTest() => propertyTest("Price", true);
    [TestMethod] public void TypeTest() => propertyTest("Type", true);
}
