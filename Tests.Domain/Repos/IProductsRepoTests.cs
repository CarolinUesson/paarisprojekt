using Domain.Common;
using Domain.Pd;
using Domain.Repos;

namespace Tests.Domain.Repos;
[TestClass] public class IProductsRepoTests : InterfaceTests<IProductsRepo, IPagedRepo<Product>>
{
}
