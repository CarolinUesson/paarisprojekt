using Data;
using Data.Parties;
using Data.Pd;
using Tests.Aids;

namespace Tests.Data.Pd;
[TestClass]
public class PartyFacilityDataTests: SealedNewTests<PartyFacilityData, EntityData> {
    [TestMethod] public void PartyIdTest() => propertyTest();
}
