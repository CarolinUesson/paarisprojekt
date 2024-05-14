using Aids.Methods;
using Domain.Pd;

namespace Tests.Aids.Methods;
[TestClass]
public class GetClassTests : BaseTests
{
    protected override Type? type => typeof(GetClass);
    [TestMethod] public void MembersTest()
    {
        var x = GetClass.Members(typeof(Product)).Select(x => x.Name);
        Assert.AreEqual(1, x.Count());
        Assert.IsTrue(x.Contains(nameof(Product.Name)));
    }
    [TestMethod] public void MemberNamesTest()
    {
        var x = GetClass.MemberNames(typeof(Product));
        Assert.AreEqual(1, x.Count());
        Assert.IsTrue(x.Contains(nameof(Product.Name)));
    }
    [TestMethod] public void AssemblyTest()
    {
        var x = GetClass.Assembly(typeof(Product));
        Assert.AreSame(x, typeof(Product).Assembly);
    }
}
