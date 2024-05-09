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
}
