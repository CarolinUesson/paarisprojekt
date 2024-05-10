namespace Tests.Aids;
public abstract class SealedTests<TClass, TBaseClass> : ClassTests<TClass, TBaseClass> where TClass : new()
{
    [TestMethod] public void isSealedTest() => Assert.IsTrue(typeof(TClass)?.IsSealed);
}
