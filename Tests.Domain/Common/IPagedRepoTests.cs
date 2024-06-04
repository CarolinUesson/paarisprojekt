using Domain.Common;
using Domain.Pd;

namespace Tests.Domain.Common;

[TestClass] public class IPagedRepoTests : InterfaceTests<IRepo<Product>>
{
    [TestMethod] public void PageNumberTest() => propertyTest<int?>();
    [TestMethod] public void PageNrAsIntTest() => propertyTest<int>(false);
    [TestMethod] public void PageSizeTest() => propertyTest<int>();
    [TestMethod] public void TotalPagesTest() => propertyTest<int>(false);
    [TestMethod] public void TotalItemsTest() => propertyTest<int>(false);
    [TestMethod] public void HasNextPageTest() => propertyTest<bool>(false);
    [TestMethod] public void HasPreviousPageTest() => propertyTest<bool>(false);
}