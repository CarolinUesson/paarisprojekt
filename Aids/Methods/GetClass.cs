﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Aids.Methods;
public static class GetClass
{
    private static readonly BindingFlags flags = BindingFlags.DeclaredOnly
        | BindingFlags.Instance
        | BindingFlags.Static
        | BindingFlags.Public;
    public static List<MemberInfo> Members(Type t) => [.. t.GetMembers(flags).Where(x => isNeeded(x.Name))];
    private static bool isNeeded(string name)
    {
        if (name.StartsWith("get_")) return false;
        if (name.StartsWith("set_")) return false;
        if (name.EndsWith(".ctor")) return false;
        return true;
    }
    public static List<string> MemberNames(Type t) => Members(t).Select(x => x.Name).ToList();
    public static Assembly Assembly(Type t) => t.Assembly;
}
