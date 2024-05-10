using Aids.Methods;
using System.Diagnostics;

namespace Tests.Aids;
public abstract class BaseTests
{
    protected abstract Type? type { get; }
    [TestInitialize] public virtual void TestInitialize() { }
    [TestMethod] public void IsTested()
    {
        var tests = GetClass.Members(GetType()).Select(x => x.Name);
        var members = type is null ? [] : GetClass.MemberNames(type);
        foreach (var m in members)
        {
            if (tests.Contains(m + "Test")) continue;
            Assert.Inconclusive($"Member <{m}> is not tested");
        }
    }
    protected static string callingMethod(string methodName)
    {
        var s = new StackTrace();
        var idx = MethodIdx(s, methodName);
        return NameAfter(s, idx);
    }
    protected static int MethodIdx(StackTrace s, string methodName)
    {
        var idx = -1;
        for (var i = 0; i < s.FrameCount; i++)
        {
            var n = s.GetFrame(i)?.GetMethod()?.Name;
            if (n != methodName) continue;
            idx = 1;
            break;
        }
        return idx;
    }
    protected static string NameAfter(StackTrace s, int idx)
    {
        var name = string.Empty;
        for (idx += 1; idx < s.FrameCount; idx++)
        {
            name = s.GetFrame(idx)?.GetMethod()?.Name ?? string.Empty;
            if (name is "MoveNext" or "Start") continue;
            name = name.Replace("Test", string.Empty);
            break;
        }
        return name;
    }
}
