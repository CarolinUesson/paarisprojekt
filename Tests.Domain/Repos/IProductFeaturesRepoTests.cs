using Domain;
using Domain.Common;
using Domain.Repos;

namespace Tests.Domain.Repos;
[TestClass] public class IProductFeaturesRepoTests : InterfaceTests<IProductFeaturesRepo, IPagedRepo<ProductFeature>>
{
}
