using Facade;
using Tests.Aids;

namespace Tests.Facade;
[TestClass] public class EntityViewTests : AbstractTests<EntityView, object>
{
    private class test : EntityView { }
    protected override EntityView? createObject() => new test();
    [TestMethod] public void IdTest() => propertyTest();
}
