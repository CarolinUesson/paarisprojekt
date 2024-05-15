using Domain.Common;
using Domain.Pd;

namespace Tests.Domain.Common;
[TestClass] public class ICrudRepoTests : InterfaceTests<ICrudRepo<Product>>
{
    [TestMethod] public void AddAsyncTest() => methodTest<Task<bool>>(typeof(Product));
    [TestMethod] public void DeleteAsyncTest() => methodTest<Task<bool>>(typeof(int));
    [TestMethod] public void GetAsyncListTest() => methodTest<Task<IEnumerable<Product>>>("List");
    [TestMethod] public void GetAsyncTest() => methodTest<Task<Product?>>(typeof(int));
    [TestMethod] public void UpdateAsyncTest() => methodTest<Task<bool>>(typeof(Product));
}    