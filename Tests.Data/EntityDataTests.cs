using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Aids;

namespace Tests.Data;
[TestClass] public class EntityDataTests : AbstractTests<EntityData, object>
{
    private class entity : EntityData { }
    protected override EntityData? createObject() => new entity();
    [TestMethod] public void IdTest() => propertyTest();


    
    
}
