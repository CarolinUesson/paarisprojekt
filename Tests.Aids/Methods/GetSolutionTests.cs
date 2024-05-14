using System.Reflection;
using Aids.Methods;

namespace Tests.Aids.Methods;
[TestClass] public class GetSolutionTests : BaseTests
{
    protected override Type? type => typeof(GetSolution);
    [TestMethod, DynamicData(nameof(testData), DynamicDataSourceType.Method)] public void AssemblyTest(string name)
    {
        var a = GetSolution.Assembly(name);
        var e = Assembly.Load(name);
        Assert.IsNotNull(e);
        Assert.AreSame(e, a);
    }
    [TestMethod, DynamicData(nameof(testData), DynamicDataSourceType.Method)] public void TypesTest(string name)
    {
        var a = GetSolution.Types(name);
        var e = GetSolution.Types(GetSolution.Assembly(name));
        Assert.AreEqual(e.Count, a.Count);
        foreach(var i in a) Assert.IsTrue(e.Contains(i));
    }
    [TestMethod, DynamicData(nameof(testData), DynamicDataSourceType.Method)] public void TypesByAssemblyTest(string name)
    {
        var assembly = Assembly.Load(name);
        var a = GetSolution.Types(assembly);
        var e = assembly.GetTypes().Where(x => !x.Name.StartsWith("<>")).ToList();
        Assert.AreEqual(e.Count, a.Count);
        foreach (var i in a) Assert.IsTrue(e.Contains(i));
    }
    private static IEnumerable<object[]> testData()
    {
        yield return new object[] { "Aids" };
        yield return new object[] { "Tests.Aids" };
    }
}
