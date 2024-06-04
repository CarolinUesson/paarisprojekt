using Domain.Common;
using Domain.Parties;
using Domain.Repos.Parties;

namespace Tests.Domain.Repos;
[TestClass]
public class IPartyFacilityRepoTests: InterfaceTests<IPartyFacilityRepo, IPagedRepo<PartyFacility>> {
}
