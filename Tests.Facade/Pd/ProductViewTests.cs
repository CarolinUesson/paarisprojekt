using Facade;
using Facade.Pd;
using Tests.Aids;

namespace Tests.Facade.Pd;
[TestClass] public class ProductViewTests : SealedNewTests<ProductView, EntityView>
{
    [TestMethod] public void NameTest() => propertyTest("Name", true);
}
