using Domain.Common;
using Domain.Pd;
using Domain.Repos;

namespace Tests.Domain.Repos;
[TestClass] public class IDeploymentsRepoTests : InterfaceTests<IDeploymentsRepo, IPagedRepo<Deployment>>
{
}
