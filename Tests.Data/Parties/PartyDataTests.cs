using Data;
using Data.Parties;
using Tests.Aids;

namespace Tests.Data.Pd;
[TestClass]
public class PartyDataTests: SealedNewTests<PartyData, EntityData> {
    [TestMethod] public void NameTest() => propertyTest();
}
