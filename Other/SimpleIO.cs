namespace Algorizem.Other;

public class SimpleIO
{
    public static readonly SimpleIO Cin = new();
    public static StreamReader reader = new(Console.OpenStandardInput());
    public static StreamWriter writer = new(Console.OpenStandardOutput(), bufferSize: 1048576);
    public static implicit operator string(SimpleIO _) => reader.ReadLine();
    public static implicit operator char[](SimpleIO _) => reader.ReadLine().ToArray();
    public static implicit operator int(SimpleIO _) => int.Parse(reader.ReadLine());
    public static implicit operator double(SimpleIO _) => double.Parse(reader.ReadLine());
    public static implicit operator string[](SimpleIO _) => reader.ReadLine().Split();
    public static implicit operator int[](SimpleIO _) => Array.ConvertAll(reader.ReadLine().Split(), int.Parse);
    public void Deconstruct(out int a, out int b) { int[] r = Cin; (a, b) = (r[0], r[1]); }
    public void Deconstruct(out int a, out int b, out int c) { int[] r = Cin; (a, b, c) = (r[0], r[1], r[2]); }
    public static void Loop(int end, Action<int> action, int start = 0, in int add = 1) { for (; start < end; start += add) action(start); }
    public static object? Cout { set { writer.Write(value); } }
    public static object? Coutln { set { writer.WriteLine(value); } }
}
