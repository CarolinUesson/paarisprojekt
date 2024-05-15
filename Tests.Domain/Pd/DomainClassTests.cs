using Aids.Methods;
using Data;
using Domain;
using Tests.Aids;

namespace Tests.Domain.Pd;
[TestClass] public abstract class DomainClassTests<TDomain, TData> : SealedTests<TDomain, Entity<TData>>
    where TData : EntityData, new() where TDomain : Entity<TData>
{
    private TData? data;
    protected override TDomain? createObject()
    {
        data = GetRnd.Object<TData>();
        var ci = type?.GetConstructor([typeof(TData)]);
        return ci is null ? null : (TDomain) ci.Invoke([data]);
    }
    public void valueTest()
    {
        var name = callingMethod(nameof(valueTest));
        var aPi = type?.GetProperty(name);
        var ePi = data?.GetType().GetProperty(name);
        var eValue = ePi?.GetValue(data);
        var aValue = aPi?.GetValue(obj);
        Assert.AreEqual(eValue, aValue);
    }
}