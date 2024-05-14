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
        var p = new ProductData();
        p.Id = GetRnd.Int32();
        p.Name = GetRnd.String();
        var v = Copy.Members<ProductData, ProductView>(p);
        Assert.IsInstanceOfType(v, typeof(ProductView));
        Assert.AreEqual(p.Id, v.Id);
        Assert.AreEqual(p.Name, v.Name);
    }
}
