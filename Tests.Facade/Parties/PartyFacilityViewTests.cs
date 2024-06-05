using Facade;
using Facade.Parties;
using Tests.Aids;

namespace Tests.Facade.Pd;
[TestClass]
public class PartyFacilityViewTests: SealedNewTests<PartyFacilityView, EntityView> {
    [TestMethod] public void PartyIdTest() => propertyTest("Party", true);
    [TestMethod] public void FacilityIdTest() => propertyTest("Facility", true);
}
