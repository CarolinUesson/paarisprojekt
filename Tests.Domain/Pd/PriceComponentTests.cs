using Data.Pd;
using Domain;
using Domain.Pd;

namespace Tests.Domain.Pd;
[TestClass] public class PriceComponentTests : DomainClassTests<PriceComponent, PriceComponentData>
{
    protected override Type baseType => typeof(Date<PriceComponentData>);
    [TestMethod] public void PriceTest() => valueTest(); 
    [TestMethod] public void TypeTest() => valueTest();
}
