using System.Reflection;

namespace Aids.Methods;
public static class GetSolution
{
    public static Assembly Assembly(string name) => System.Reflection.Assembly.Load(name);
    public static List<Type> Types(string assemblyName) => 
        Assembly(assemblyName).GetTypes().Where(x => !x.Name.StartsWith("<>")).ToList();
}
