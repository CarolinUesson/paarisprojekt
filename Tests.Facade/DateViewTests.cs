using Facade;
using Tests.Aids;

namespace Tests.Facade;
[TestClass]
public class DateViewTests : AbstractTests<DateView, EntityView>
{
    private class date : DateView { }
    protected override DateView? createObject() => new date();
    [TestMethod] public void FromDateTest() => propertyTest("FromDate", true);
    [TestMethod] public void ThruDateTest() => propertyTest("ThruDate", true);
}
