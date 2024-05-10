using Aids.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Aids;
public abstract class AssemblyTests
{
    [TestMethod]
    public void IsTested()
    {
        var assembly = GetClass.Assembly(GetType());
        var assemblyName = assembly.FullName ?? string.Empty;
        var solutionName = assemblyName.Replace("Tests.", "");
        var types = GetSolution.Types(solutionName).Select(x => x.Name.Replace("`1", string.Empty));
        var tests = GetSolution.Types(assemblyName).Select(x => x.Name);
        foreach (var t in types)
        {
            if (tests.Contains(t + "Tests")) continue;
            Assert.Inconclusive($"Type <{t}> is not tested");
        }
    }
}
