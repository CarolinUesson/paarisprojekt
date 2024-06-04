using Data.Parties;
using Domain.Parties;
using Tests.Domain.Pd;

namespace Tests.Domain.Parties;
[TestClass]
public class PartyTests: DomainClassTests<Party, PartyData> {
    [TestMethod] public void NameTest() => valueTest();
}