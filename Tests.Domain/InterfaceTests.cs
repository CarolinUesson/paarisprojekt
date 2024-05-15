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
    protected void propertyTest<TPropertyType>(bool isReadOnly = true)
    {
        var name = callingMethod(nameof(propertyTest));
        var pi = type?.GetProperty(name);
        Assert.IsNotNull(pi);
        var t = pi.PropertyType;
        Assert.AreEqual(typeof(TPropertyType), t);
        Assert.AreEqual(pi.CanRead, true);
        Assert.AreEqual(pi.CanWrite, isReadOnly);
    }
    protected void methodTest<TReturnType>(params Type[] expectedParameters)
    {
        var name = callingMethod(nameof(methodTest));
        methodTest(typeof(TReturnType), name, expectedParameters);
    }
    protected void methodTest<TReturnType>(string replaceInName, params Type[] expectedParameters)
    {
        var name = callingMethod(nameof(methodTest)).Replace(replaceInName, string.Empty);
        methodTest(typeof(TReturnType), name, expectedParameters);
    }
    protected void methodTest(Type returnType, string name, params Type[] expectedParameters)
    {
        var mi = type?.GetMethod(name, expectedParameters);
        Assert.IsNotNull(mi);
        Assert.AreEqual(returnType, mi.ReturnType);
    }
}
