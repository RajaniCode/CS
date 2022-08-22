using System;
using System.Text;

class Program 
{   
    void Print(Type type) 
    {       
        Console.WriteLine("IsArray: " + type.IsArray);
        Console.WriteLine("Name: " + type.Name);
        Console.WriteLine("IsSealed: " + type.IsSealed);
        Console.WriteLine("BaseType.Name: " + type.BaseType.Name);
        Console.WriteLine();
    }

    static void Main() 
    {        
        Type type1 = typeof(StringBuilder);
        Type type2 = typeof(String);
        Type type3 = typeof(string[]);

        Object o = Activator.CreateInstance(typeof(StringBuilder));
        StringBuilder builder = (StringBuilder) o;
        builder.Append("Hello, World!");
        string s = builder.ToString();
        Console.WriteLine(s);
        Console.WriteLine();

        Program prgm = new Program();
        prgm.Print(type1);
        prgm.Print(type2);
        prgm.Print(type3);
    }
}