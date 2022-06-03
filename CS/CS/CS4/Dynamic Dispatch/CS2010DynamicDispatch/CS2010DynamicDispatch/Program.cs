using System;
using System.Reflection;

class Maths
{
    public int Square(int Integer)
    {
        return Integer * Integer;
    }
}

class Program
{
    static void Method()
    {
        object Instance = new Maths();
        Type InstanceType = Instance.GetType();
        object Result = InstanceType.InvokeMember("Square", BindingFlags.InvokeMethod, null, Instance, new object[] { 1 });

        int Number = Convert.ToInt32(Result);
        Console.WriteLine(Number);

        dynamic Runtime = new Maths();

        Number = Runtime.Square(2);
        Console.WriteLine(Number);
    }

    static void MethodFromAssembly()
    {
        Assembly AssemblyName = Assembly.LoadFrom("Sample.dll");
        Type AssemblyTypeName = AssemblyName.GetType("Maths");
        object Instance = Activator.CreateInstance(AssemblyTypeName);
        object Result = AssemblyTypeName.InvokeMember("Square", BindingFlags.InvokeMethod, null, Instance, new object[] { 3 });

        int Number = Convert.ToInt32(Result);
        Console.WriteLine(Number);

        dynamic Runtime = Activator.CreateInstance(AssemblyTypeName);     
        Number = Runtime.Square(4);
        Console.WriteLine(Number);       
    }    

    static void Main()
    {
        Method();
        MethodFromAssembly();
        Console.ReadKey();
    }
}


/*
//Sample.dll
//Sample.cs
using System;

public class Maths
{
    public int Square(int Integer)
    {
	return Integer * Integer;
    }
}
*/