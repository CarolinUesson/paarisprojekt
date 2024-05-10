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
        var types = GetSolution.Types("Aids").Select(x => x.Name);
        var tests = GetSolution.Types("Tests.Aids").Select(x => x.Name);
        foreach (var t in types)
        {
            if (tests.Contains(t + "Tests")) continue;
            Assert.Inconclusive($"{t} is not tested");
        }
    }
}
