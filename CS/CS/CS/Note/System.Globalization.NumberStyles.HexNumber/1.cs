// System.Globalization.NumberStyles.HexNumber


using System;
using System.Collections.Generic; // Note

class MyClass
{
    public string IntToHex(int number)
    {
        return String.Format("{0:X}", number);
    }

    public int HexToInt(string hexString)
    {
        return int.Parse(hexString, System.Globalization.NumberStyles.HexNumber, null);
    } 
}

class MainClass
{
    static void Main()
    {
        int i = 100;
        string str = Convert.ToString(i, 16); //base = 2, 8,10 or 16
        Console.WriteLine(str);
        Console.WriteLine(0x64);
        MyClass mc = new MyClass();
        Console.WriteLine("Integer to Hexadecimal: {0} \n", mc.IntToHex(100));
        Console.WriteLine("Hexadecimal to Integer: {0} \n", mc.HexToInt("64"));
    }
}
        