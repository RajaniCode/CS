// reflection 


// invoking methods using reflection


using System;
using System.Reflection; // Note

class MyClass
{
    int x;
    int y;

    public MyClass(int k, int l) 
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
        if((x<a) && (a<x))
            return true;
        else
            return false;
    }

    public void setMethod(int a, int b) 
    {
        x = a;
        y = b;
    }
     
    public void setMethod(double a, double b) 
    {
        x = (int)a;
        y = (int)b;
    }    

    void printMethod() // Note: NonPublic
    {
        Console.WriteLine("x = {0}, y = {1}", x, y);
    }

    public static void myMethod() // Note: Static
    {
        Console.WriteLine("static method");    
    }   
}

class MainClass
{
    static void Main()
    {
        Type t = typeof(MyClass);

        Console.WriteLine("Analyzing methods in {0}", t.FullName);
        
        Console.WriteLine("Methods are: ");

        MethodInfo[] mo = t.GetMethods(BindingFlags.DeclaredOnly |
                                       BindingFlags.Public |
                                       BindingFlags.NonPublic |
                                       BindingFlags.Instance |
                                       BindingFlags.Static);

  
        foreach(MethodInfo m in mo)
        {
            Console.Write(m.ReturnType.Name + " " + m.Name + "(");

            ParameterInfo[] po = m.GetParameters(); //Note: m not t
            
            for(int i=0; i<po.Length; i++)
            {
                Console.Write(po[i].ParameterType.Name + " " + po[i].Name);
                
                if(i+1 < po.Length)
                    Console.Write(" , ");
   
            }
            Console.Write(")");
            Console.WriteLine();            
        }
    }
}