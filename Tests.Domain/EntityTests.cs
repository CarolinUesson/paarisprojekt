using Aids.Methods;
using Data;
using Data.Pd;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Aids;

namespace Tests.Domain;
[TestClass]
public class EntityTests : AbstractTests<Entity<ProductFeatureData>, object>
{
    private class entity(ProductFeatureData? d) : Entity<ProductFeatureData>(d) { }
    private dynamic? data;
    protected override Entity<ProductFeatureData>? createObject()
    {
        data = GetRnd.Object<ProductFeatureData>();
        return new entity(data);
    }
    [TestMethod] public void IdTest() => Assert.AreEqual(data?.Id, obj?.Id);
}
