using Aids.Methods;

namespace Tests.Aids.Methods;
[TestClass]
public class GetRndTests : BaseTests
{
    protected override Type? type => typeof(GetRnd);
    [TestMethod] public void BoolTest() => testRnd(GetRnd.Bool);
    [TestMethod] public void CharTest() => testRnd(() => GetRnd.Char(), GetRnd.Char);
    [TestMethod] public void DateTimeTest() => testRnd(() => GetRnd.DateTime(), (x, y) => GetRnd.DateTime(x, y));
    [TestMethod] public void DoubleTest() => testRnd(() => GetRnd.Double(), GetRnd.Double);
    [TestMethod] public void StringTest() => Assert.AreNotEqual(GetRnd.String(), GetRnd.String());
    [TestMethod] public void Int8Test() => testRnd(() => GetRnd.Int8(), GetRnd.Int8);
    [TestMethod] public void UInt8Test() => testRnd(() => GetRnd.UInt8(), GetRnd.UInt8);
    [TestMethod] public void Int16Test() => testRnd(() => GetRnd.Int16(), GetRnd.Int16);
    [TestMethod] public void UInt16Test() => testRnd(() => GetRnd.UInt16(), GetRnd.UInt16);
    [TestMethod] public void Int32Test() => testRnd(() => GetRnd.Int32(), GetRnd.Int32);
    [TestMethod] public void UInt32Test() => testRnd(() => GetRnd.UInt32(), GetRnd.UInt32);
    [TestMethod] public void Int64Test() => testRnd(() => GetRnd.Int64(), GetRnd.Int64);
    [TestMethod] public void UInt64Test() => testRnd(() => GetRnd.UInt64(), GetRnd.UInt64);
    private static void testRnd<T>(Func<T> f) where T : IComparable<T>
    {
        T x = f();
        T y = f();
        while (x.CompareTo(y) == 0) y = f();
        Assert.AreNotEqual(x, y);
    }
    private static void testRnd<T>(Func<T> f1, Func<T, T, T>? f2 = null) where T : IComparable<T>
    {
        testRnd(f1, out T min, out T max);
        if (f2 is null) return;
        testRnd(() => f2(min, max), out T x, out T y);
        if (min.CompareTo(max) < 0) isBetween(x, min, max);
        else isBetween(x, max, min);
    }
    private static void testRnd<T>(Func<T> f, out T x, out T y) where T : IComparable<T>
    {
        x = f();
        y = f();
        while (x.CompareTo(y) == 0) y = f();
        Assert.AreNotEqual(x, y);
    }
    private static void isBetween<T>(T x, T min, T max) where T : IComparable<T>
    {
        Assert.IsTrue(x.CompareTo(max) <= 0);
        Assert.IsTrue(x.CompareTo(min) >= 0);
    }
}
