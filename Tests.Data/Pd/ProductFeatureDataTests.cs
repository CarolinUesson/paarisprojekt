using Data;
using Data.Pd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Aids;

namespace Tests.Data.Pd;
[TestClass] public class ProductFeatureDataTests : SealedNewTests<ProductFeatureData, EntityData>
{
    [TestMethod] public void DescriptionTest() => propertyTest();
}
