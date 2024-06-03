using Data.Parties;
using Data.Pd;
using Domain;
using Domain.Parties;
using Tests.Domain.Pd;

namespace Tests.Domain;
[TestClass]
public class PartyFacilityTests: DomainClassTests<PartyFacility, PartyFacilityData> {
    [TestMethod] public void PartyIdTest() => valueTest();
}
