// reflection

// calling methods using reflection

using System;
using System.Reflection;

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

class MainClass
{
    static void Main()
    {
        MyClass mc = new MyClass(10, 20);

        Type t = typeof(MyClass);

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
                m.Invoke(mc, args);
            }

            else if((m.Name.CompareTo("setMethod")==0) && (po[0].ParameterType==typeof(double))) // ParameterType due to overloading
            {
                object[] args = new object[2];
                args[0] = 1.12D;
                args[1] = 23.4D;
                m.Invoke(mc, args); // return type, void 
            }

            else if(m.Name.CompareTo("isBetweenMethod")==0)
            {
                object[] args = new object[1];
                args[0] = 14;
                if((bool)m.Invoke(mc, args)) // return type, bool
                    Console.WriteLine("14 number is between x and y");
                else
                    Console.WriteLine("14 number is not between x and y");  
            }

            else if(m.Name.CompareTo("additionMethod")==0)
            {
                Console.WriteLine("Addition = {0}", ((int) m.Invoke(mc , null)));  // return type, int            
            }

            else if(m.Name.CompareTo("printMethod")==0)
            {
                m.Invoke(mc, null); // return type, void              
            }
        }
    }
}
              












        
    
    
   
    
    