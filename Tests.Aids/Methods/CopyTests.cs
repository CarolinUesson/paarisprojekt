using Aids.Methods;
using Data.Pd;
using Facade.Pd;

namespace Tests.Aids.Methods;
[TestClass]
public class CopyTests : BaseTests
{
    protected override Type? type => typeof(Copy);
    [TestMethod] public void MembersTest()
    {
        var p = GetRnd.Object<ProductData>();
        var v = Copy.Members<ProductData, ProductView>(p);
        Assert.IsInstanceOfType(v, typeof(ProductView));
        areEqualProperties(v, p);
    }
}
