using Facade;
using Facade.Parties;
using Tests.Aids;

namespace Tests.Facade.Pd;
[TestClass]
public class FacilityViewTests: SealedNewTests<FacilityView, EntityView> {
    [TestMethod] public void LocationTest() => propertyTest("Location", true);
}
