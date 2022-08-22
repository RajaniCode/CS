// Reflection // Assembly // AppDomain // Directory


using System;

class MainClass
{
    static void Main()
    {
        Type t = typeof(object);

        Console.WriteLine(t.FullName);
        Console.WriteLine(t);
        Console.WriteLine(t.Name);

        if (t.IsClass)
            Console.WriteLine("{0} is a class" + "\n", t);

        if (!t.IsAbstract)
            Console.WriteLine("{0} is not an abstract but a concrete class" + "\n", t);

        Console.Write("Class Name (from static method): ");
        MainClass mc = new MainClass();
        Console.WriteLine(mc.GetType().Name + "\n");

        mc.B();

        Console.Read();
    }

    public void B()
    {
        A();
    }

    public void A()
    {
        Console.WriteLine("Application Name:");
        Console.WriteLine(System.Reflection.Assembly.GetEntryAssembly().GetName().Name);
        Console.WriteLine(System.AppDomain.CurrentDomain.DomainManager.EntryAssembly.GetName().Name);
        // Add Reference to System.Windows.Forms.dll
        Console.WriteLine(System.Windows.Forms.Application.ProductName + "\n");

        Console.WriteLine("Application BaseDirectory:");
        Console.WriteLine(System.AppDomain.CurrentDomain.BaseDirectory);
        Console.WriteLine(System.IO.Directory.GetCurrentDirectory() + "\n");

        Console.WriteLine("Application Directory:");
        Console.WriteLine(System.IO.Directory.GetParent(System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).ToString()).ToString() + "\n");

        Console.Write("Class Name (from instance method): ");
        Console.WriteLine(GetType().Name + "\n");

        Console.Write("Called Method Name: ");
        Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name + "\n");

        Console.Write("Calling Method Name: ");
        System.Diagnostics.StackTrace traceStack = new System.Diagnostics.StackTrace();
        System.Diagnostics.StackFrame frameStack = traceStack.GetFrame(1);
        System.Reflection.MethodBase baseMethod = frameStack.GetMethod();
        Console.WriteLine(baseMethod.Name + "\n");

        Type t1 = typeof(MainClass);

        System.Reflection.MethodInfo[] infoMethod = t1.GetMethods();

        foreach (System.Reflection.MethodInfo infMthd in infoMethod)
        {
            Console.Write("Methods: ");
            Console.WriteLine(infMthd.Name); // Only public methods (built-in and user defined)
        }
    }
}


/*
OUTPUT:

System.Object
System.Object
Object
System.Object is a class

System.Object is not an abstract but a concrete class

Class Name (from static method): MainClass

Application Name:
ConsoleApplication1
ConsoleApplication1
ConsoleApplication1

Application BaseDirectory:
C:\Documents and Settings\RAJANI\Desktop\ConsoleApplication1\ConsoleApplication1
\bin\Debug\
C:\Documents and Settings\RAJANI\Desktop\ConsoleApplication1\ConsoleApplication1
\bin\Debug

Application Directory:
C:\Documents and Settings\RAJANI\Desktop\ConsoleApplication1\ConsoleApplication1


Class Name (from instance method): MainClass

Called Method Name: A

Calling Method Name: B

Methods: B
Methods: A
Methods: ToString
Methods: Equals
Methods: GetHashCode
Methods: GetType

*/