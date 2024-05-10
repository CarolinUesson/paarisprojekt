namespace Tests.Aids;
public abstract class SealedNewTests<TClass, TBaseClass> : ClassTests<TClass, TBaseClass> where TClass : class, new()
{
    protected override TClass? createObject() => new();
    [TestMethod] public void isSealedTest() => Assert.IsTrue(typeof(TClass)?.IsSealed);
}
