using Facade;
using Tests.Aids;

namespace Tests.Facade;
[TestClass] public class EntityViewTests : AbstractTests<EntityView, object>
{
    private class entity : EntityView { }
    protected override EntityView? createObject() => new entity();
    [TestMethod] public void IdTest() => propertyTest();
}
