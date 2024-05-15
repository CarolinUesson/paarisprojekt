using Domain;

namespace Tests.Domain;
[TestClass] public class IEntityTests : InterfaceTests<IEntity>
{
    [TestMethod] public void IdTest() => propertyTest<int>();
}
