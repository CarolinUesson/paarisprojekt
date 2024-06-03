using System.Text;

namespace Aids.Methods;
public class GetRnd
{
    private static readonly Random r = new();
    public static bool Bool() => Int32() % 2 == 0;
    public static char Char(char min = char.MinValue, char max = char.MaxValue) => (char)UInt16(min, max);
    public static DateTime DateTime(DateTime? min = null, DateTime? max = null)
    {
        var minValue = (min ?? System.DateTime.Today.AddYears(5)).Ticks;
        var maxValue = (max ?? System.DateTime.Today.AddYears(-5)).Ticks;
        var ticks = Int64(minValue, maxValue);
        return new DateTime(ticks);
    }
    public static decimal Decimal(decimal min = decimal.MinValue, decimal max = decimal.MaxValue)
    {
        int[] bits = new int[4];
        bits[0] = Int32();
        bits[1] = Int32();
        bits[2] = Int32();
        bits[3] = 0;
        var d = new Decimal(bits);
        if (d < min || d > max)
        {
            Decimal range = max - min;
            Decimal fractions = d / decimal.MaxValue;
            d = min + fractions * range;
        }
        return d;
    }
    public static double Double(double min = short.MinValue, double max = short.MaxValue)
    {
        if (min > max)
        {
            var x = min;
            min = max;
            max = x;
        }
        var d = r.NextDouble();
        return max > 0 ? min + d * max - d * min : min - d * min + d * max;
    }
    public static string String(byte minLength = 10, byte maxLength = 20)
    {
        var b = new StringBuilder();
        var size = UInt8(minLength, maxLength);
        for (var i = 0; i < size; i++) b.Append(Char('a', 'z'));
        return b.ToString();
    }
    public static sbyte Int8(sbyte min = sbyte.MinValue, sbyte max = sbyte.MaxValue) => (sbyte)Int32(min, max);
    public static byte UInt8(byte min = byte.MinValue, byte max = byte.MaxValue) => (byte)Int32(min, max);
    public static short Int16(short min = short.MinValue, short max = short.MaxValue) => (short)Int32(min, max);
    public static ushort UInt16(ushort min = ushort.MinValue, ushort max = ushort.MaxValue) => (ushort)Int32(min, max);
    public static int Int32(int min = int.MinValue, int max = int.MaxValue) => min == max ? min : max < min ? r.Next(max, min) : r.Next(min, max);
    public static uint UInt32(uint min = uint.MinValue, uint max = uint.MaxValue) => (uint)Double(min, max);
    public static long Int64(long min = long.MinValue, long max = long.MaxValue) => (long)Double(min, max);
    public static ulong UInt64(ulong min = ulong.MinValue, ulong max = ulong.MaxValue) => (ulong)Double(min, max);
    public static dynamic? Any(Type? t)
    {
        if (t == typeof(bool)) return Bool();
        if (t == typeof(bool?)) return Bool();
        if (t == typeof(char)) return Char();
        if (t == typeof(char?)) return Char();
        if (t == typeof(DateTime)) return DateTime();
        if (t == typeof(DateTime?)) return DateTime();
        if (t == typeof(decimal)) return Decimal();
        if (t == typeof(decimal?)) return Decimal();
        if (t == typeof(double)) return Double();
        if (t == typeof(double?)) return Double();
        if (t == typeof(string)) return String();
        if (t == typeof(sbyte)) return Int8();
        if (t == typeof(sbyte?)) return Int8();
        if (t == typeof(byte)) return UInt8();
        if (t == typeof(byte?)) return UInt8();
        if (t == typeof(short)) return Int16();
        if (t == typeof(short?)) return Int16();
        if (t == typeof(ushort)) return UInt16();
        if (t == typeof(ushort?)) return UInt16();
        if (t == typeof(int)) return Int32();
        if (t == typeof(int?)) return Int32();
        if (t == typeof(uint)) return UInt32();
        if (t == typeof(uint?)) return UInt32();
        if (t == typeof(long)) return Int64();
        if (t == typeof(long?)) return Int64();
        if (t == typeof(ulong)) return UInt64();
        if (t == typeof(ulong?)) return UInt64();
        else return null;
    }
    public static TObject Object<TObject>() where TObject : class, new()
    {
        var o = new TObject();
        foreach(var p in o.GetType().GetProperties())
        {
            if(!p.CanWrite) continue;
            var v = Any(p.PropertyType);
            p.SetValue(o, v, null);
        }
        return o;
    }
}
