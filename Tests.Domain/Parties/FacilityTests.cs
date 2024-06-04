using Data.Parties;
using Data.Pd;
using Domain;
using Domain.Parties;
using Tests.Domain.Pd;

namespace Tests.Domain;
[TestClass]
public class FacilityTests: DomainClassTests<Facility, FacilityData> {
    [TestMethod] public void LocationTest() => valueTest();
}