using Tests.Aids;

namespace Tests.Domain;

public class InterfaceTests<TType, TBaseType> : InterfaceTests<TType>
{
    [TestMethod]
    public void IsBaseTypeTest() =>
        Assert.IsNotNull(typeof(TType)?.GetInterface(typeof(TBaseType).Name));
}
public class InterfaceTests<TType> : BaseTests
{
    protected override Type? type => typeof(TType);
    [TestMethod] public void IsInterface() => Assert.IsTrue(type?.IsInterface);
    protected void propertyTest<TPropertyType>()
    {
        var name = callingMethod(nameof(propertyTest));
        var pi = type?.GetProperty(name);
        Assert.AreEqual(typeof(TPropertyType), pi?.PropertyType);
    }
}
