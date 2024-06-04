using Facade;
using Facade.Parties;
using Facade.Pd;
using Tests.Aids;

namespace Tests.Facade.Pd;
[TestClass]
public class PartyViewTests: SealedNewTests<PartyView, EntityView> {
    [TestMethod] public void NameTest() => propertyTest("Name", true);
}
