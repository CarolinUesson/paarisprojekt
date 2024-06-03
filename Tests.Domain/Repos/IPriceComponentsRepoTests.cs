using Domain.Common;
using Domain.Pd;
using Domain.Repos;

namespace Tests.Domain.Repos;
[TestClass] public class IPriceComponentsRepoTests : InterfaceTests<IPriceComponentsRepo, IPagedRepo<PriceComponent>>
{
}
