using Aids.Methods;
using Data.Pd;
using Domain;
using System;
using Tests.Aids;

namespace Tests.Domain;
[TestClass]
public class DateTests : AbstractTests<Date<DeploymentData>, Entity<DeploymentData>>
{
    private class date(DeploymentData? d) : Date<DeploymentData>(d) { }
    private dynamic? data;
    protected override Date<DeploymentData>? createObject()
    {
        data = GetRnd.Object<DeploymentData>();
        return new date(data);
    }
    [TestMethod] public void FromDateTest() => Assert.AreEqual(data?.FromDate, obj?.FromDate);
    [TestMethod] public void ThruDateTest() => Assert.AreEqual(data?.ThruDate, obj?.ThruDate);
}
