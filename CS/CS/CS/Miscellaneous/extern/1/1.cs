// extern

using System;
using System.Runtime.InteropServices;

public class MainClass 
{
    [DllImport("cmdll.dll")]
    public static extern int SampleMethod(int x);
    static void Main() 
    {
        Console.WriteLine("SampleMethod() returns {0}.", 
                SampleMethod(5));
    }
}