using Domain.Common;
using Domain.Pd;

namespace Tests.Domain.Common;

[TestClass] public class IPagedRepoTests : InterfaceTests<IPagedRepo<Product>>
{
    [TestMethod] public void PageNumberTest() => propertyTest<int?>();
    [TestMethod] public void PageNrAsIntTest() => propertyTest<int>();
    [TestMethod] public void PageSizeTest() => propertyTest<int>();
    [TestMethod] public void TotalPagesTest() => propertyTest<int>();
    [TestMethod] public void TotalItemsTest() => propertyTest<int>();
    [TestMethod] public void HasNextPageTest() => propertyTest<bool>();
    [TestMethod] public void HasPreviousPageTest() => propertyTest<bool>();
}