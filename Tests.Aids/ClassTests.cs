namespace Tests.Aids;
public abstract class ClassTests<TClass, TBaseClass> : AbstractTests<TClass, TBaseClass> where TClass : new()
{
    protected TClass? obj;
    [TestInitialize] public void TestInitialize() => obj = new TClass();
    [TestMethod]public override void isAbstractTest() => Assert.IsFalse(typeof(TClass)?.IsAbstract);
    [TestMethod] public void canCreateTest() => Assert.IsInstanceOfType(obj, typeof(TClass));
}
