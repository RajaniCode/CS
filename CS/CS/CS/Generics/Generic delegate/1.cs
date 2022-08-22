// Generic delegate // static method


using System;

delegate T MyDelegate<T>(T t);

class MyClass
{
    public static int sumMethod(int np) // #Note: return type and parameter type and that of delegate's
    {
        int result = 0;
        for(int i=0; i<=np; i++)
            result += i;
        return result;
    }

    public static string reverseMethod(string sp)
    {
        string result = string.Empty;
        foreach(char c in sp)
            result = c + result;
        return result;
    }
}

class MainClass
{
    static void Main()
    {
        MyDelegate<int> md1 = MyClass.sumMethod;        // #Note <int> MUST
         
        Console.WriteLine(md1(3));

        MyDelegate<string> md2 = MyClass.reverseMethod; // #Note <string> MUST
        
        Console.WriteLine(md2("Hello"));
    }
}
        
        
        