using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
public class Person
{
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
    public string Name = null;
    public int Age = 0;
}

unsafe class HelloWorld
{
    [DllImport("libhello.so")]
    public static extern int soma();
    [DllImport("libhello.so")]
    public static extern void hello();
    [DllImport("libhello.so")]
    public static extern void say_name(string name);
    [DllImport("libhello.so", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    public static extern Person create_person(string name, int age);
    [DllImport("libhello.so", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    public static extern void print_person(ref Person p);

    static void Main ()
    {
        Console.WriteLine("This is C# program");
        int s = soma();
        Console.WriteLine("Called from C# => " + s);
        hello();
        string name = "Andre Herman";
        say_name(name);
        Person p = create_person("Andre", 41);
        Console.WriteLine($"Called from C# => Person has name {p.Name} and age {p.Age}");
        Person p2 = new();
        p2.Name = "Andre";
        p2.Age = 41;
        print_person(ref p2);
    }
}
