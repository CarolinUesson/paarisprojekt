using Data;
using Tests.Aids;

namespace Tests.Data;
[TestClass]
public class DateDataTests : AbstractTests<DateData, EntityData>
{
    private class date : DateData { }
    protected override DateData? createObject() => new date();
    [TestMethod] public void FromDateTest() => propertyTest();
    [TestMethod] public void ThruDateTest() => propertyTest();
}
