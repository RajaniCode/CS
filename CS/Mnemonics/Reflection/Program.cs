// Reflection // CS // Java

using System;
using System.Reflection;

class Reflect
{
    int x;
    int y;
   
    public Reflect(int k, int l)
    {
        x = k;
        y = l;
    }

    public int additionMethod()
    {
        return x + y;
    }

    public bool isBetweenMethod(int a)
    {
        if((x<a) && (a<y))
            return true;
        else
            return false;
    }

    public void setMethod(int a, int b)
    {
        Console.Write("Inside setMethod(int a, int b): ");
        x = a;
        y = b;
        printMethod();
    }

    public void setMethod(double a, double b)
    {
        Console.Write("Inside setMethod(double a, double b): ");
        x = (int)a;
        y = (int)b;
        printMethod();
    }

    public void printMethod()
    {
        Console.WriteLine("x = {0}, y = {1}", x, y);
    }
}

class Program
{
    static void Main()
    {
        Reflect rflct = new Reflect(10, 20);

        Type t = typeof(Reflect);

        Console.WriteLine("Invoking methods in {0}",   t.Name);
    
        MethodInfo[] mo = t.GetMethods();

        foreach(MethodInfo m in mo)
        {
            ParameterInfo[] po = m.GetParameters();
            
            if((m.Name.CompareTo("setMethod")==0) && (po[0].ParameterType==typeof(int))) // ParameterType due to overloading
            {
                object[] args = new object[2];
                args[0] = 9;
                args[1] = 18;
                m.Invoke(rflct, args);
            }

            else if((m.Name.CompareTo("setMethod")==0) && (po[0].ParameterType==typeof(double))) // ParameterType due to overloading
            {
                object[] args = new object[2];
                args[0] = 1.12D;
                args[1] = 23.4D;
                m.Invoke(rflct, args); // return type, void 
            }

            else if(m.Name.CompareTo("isBetweenMethod")==0)
            {
                object[] args = new object[1];
                args[0] = 14;
                if((bool)m.Invoke(rflct, args)) // return type, bool
                    Console.WriteLine("14 number is between x and y");
                else
                    Console.WriteLine("14 number is not between x and y");  
            }

            else if(m.Name.CompareTo("additionMethod")==0)
            {
                Console.WriteLine("Addition = {0}", ((int) m.Invoke(rflct , null)));  // return type, int            
            }

            else if(m.Name.CompareTo("printMethod")==0)
            {
                m.Invoke(rflct, null); // return type, void              
            }
        }
    }
}

// Output
/*
/Users/rajaniapple/Desktop/Mnemonics/Reflection/Program.cs(88,20): warning CS8605: Unboxing a possibly null value. [/Users/rajaniapple/Desktop/Mnemonics/Reflection/Reflection.csproj]
/Users/rajaniapple/Desktop/Mnemonics/Reflection/Program.cs(96,54): warning CS8605: Unboxing a possibly null value. [/Users/rajaniapple/Desktop/Mnemonics/Reflection/Reflection.csproj]
Invoking methods in Reflect
Addition = 30
14 number is between x and y
Inside setMethod(int a, int b): x = 9, y = 18
Inside setMethod(double a, double b): x = 1, y = 23
x = 1, y = 23
*/