using Data;
using Data.Parties;
using Tests.Aids;

namespace Tests.Data.Pd;
[TestClass]
public class FacilityDataTests: SealedNewTests<FacilityData, EntityData> {
    [TestMethod] public void LocationTest() => propertyTest();
}
