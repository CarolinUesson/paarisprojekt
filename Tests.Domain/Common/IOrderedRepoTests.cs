using Domain.Common;
using Domain.Pd;

namespace Tests.Domain.Common;

[TestClass] public class IOrderedRepoTests : InterfaceTests<IOrderedRepo<Product>, IFilteredRepo<Product>>
{
    [TestMethod] public void SortOrderTest() => propertyTest<string>();
}
    
