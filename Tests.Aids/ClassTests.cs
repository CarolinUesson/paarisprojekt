namespace Tests.Aids;
public abstract class ClassTests<TClass, TBaseClass> : AbstractTests<TClass, TBaseClass> where TClass : class
{
    [TestMethod]public override void isAbstractTest() => Assert.IsFalse(typeof(TClass)?.IsAbstract);
    [TestMethod] public void canCreateTest() => Assert.IsInstanceOfType(obj, typeof(TClass));
}
