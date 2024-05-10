using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Aids;
using Facade.Pd;
using Facade;

namespace Tests.Facade.Pd;
[TestClass] public class ProductFeatureViewTests : SealedNewTests<ProductFeatureView, EntityView>
{
    [TestMethod] public void DescriptionTest() => propertyTest("Description", true);
}
