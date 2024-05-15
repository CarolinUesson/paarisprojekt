using Domain.Common;
using Domain.Pd;

namespace Tests.Domain.Common;

[TestClass] public class IFilteredRepoTests : InterfaceTests<IFilteredRepo<Product>, ICrudRepo<Product>>
{
    [TestMethod] public void SearchStringTest() => propertyTest<string>();
}
    
