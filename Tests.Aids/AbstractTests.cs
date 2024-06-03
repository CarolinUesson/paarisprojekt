using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Aids.Methods;

namespace Tests.Aids;
public abstract class AbstractTests<TClass, TBaseClass> : BaseTests
{
    protected TClass? obj;
    [TestInitialize] public override void TestInitialize()
    {
        base.TestInitialize();
        obj = createObject();
    }
    protected abstract TClass? createObject();
    protected override Type? type => typeof(TClass);
    protected virtual Type baseType => typeof(TBaseClass);
    [TestMethod] public void isCorrectBaseClass() => Assert.AreEqual(type?.BaseType?.Name, baseType.Name);
    [TestMethod] public virtual void isAbstractTest() => Assert.IsTrue(typeof(TClass)?.IsAbstract);
    protected void propertyTest(string displayName = null, bool? isRequired = null)
    {
        var name = callingMethod(nameof(propertyTest));
        var pi = type?.GetProperty(name);
        validateDisplayName(pi, displayName);
        validateIsRequired(pi, isRequired);


        var t = pi?.PropertyType;
        var v = GetRnd.Any(t);
        Assert.IsNotNull(v, $"GetRandom.Any returns null for type <{t?.Name}>");
        pi?.SetValue(obj, v);
        Assert.AreEqual(v, pi?.GetValue(obj));
    }

    private static void validateIsRequired(PropertyInfo? pi, bool? isRequired)
    {
        if (isRequired is null) return;
        if (pi is null) return;
        var actual = pi.GetCustomAttribute<RequiredAttribute>();
        Assert.AreEqual(actual is not null, isRequired);
    }

    private static void validateDisplayName(PropertyInfo? pi, string displayName)
    {
        if (displayName is null) return;
        if (pi is null) return;
        var actual = pi.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName;
        Assert.AreEqual(displayName, actual);
    }
}
