using Domain.Common;
using Domain.Parties;
using Domain.Repos.Parties;

namespace Tests.Domain.Repos;
[TestClass]
public class IPartyRepoTests: InterfaceTests<IPartyRepo, IRepo<Party>> {
}
