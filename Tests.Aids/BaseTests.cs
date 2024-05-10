using Aids.Methods;

namespace Tests.Aids;
public abstract class BaseTests
{
    protected abstract Type? type { get; }
    [TestMethod]
    public void IsTested()
    {
        var tests = GetClass.Members(GetType()).Select(x => x.Name);
        var members = type is null ? [] : GetClass.MemberNames(type);
        foreach (var m in members)
        {
            if (tests.Contains(m + "Test")) continue;
            Assert.Inconclusive($"Member <{m}> is not tested");
        }
    }
}
