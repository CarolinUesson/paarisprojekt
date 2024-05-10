namespace Tests.Aids;

public abstract class SealedTests<TClass, TBaseClass> : ClassTests<TClass, TBaseClass> where TClass : class
{
    [TestMethod] public void isSealedTest() 
        => Assert.IsTrue(typeof(TClass)?.IsSealed);
}
