// reflection 


//obtaining a type's constructor

using System;
using System.Reflection; // Note

class MyClass
{
    int x;
    int y;

    public MyClass(int k)
    {
        x = y = k;
    }

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
        Type t = typeof(MyClass);
        
        Console.WriteLine("Obtaining constructors of {0}", t.Name);
    
        ConstructorInfo[] co = t.GetConstructors();

        foreach(ConstructorInfo c in co)
        {
            Console.Write(t.Name + "("); // Note
    
            ParameterInfo[] po = c.GetParameters();
    
            for(int i=0; i<po.Length; i++)
            {
                Console.Write(po[i].ParameterType.Name + " " + po[i].Name);

                if(i+1 < po.Length)
                    Console.Write(" , ");
            }
            Console.Write(")");
            Console.WriteLine();
        }

        //********For matching constructor with two parameters********

        int x; 
        
        for(x=0; x<co.Length; x++)
        {
            ParameterInfo[] po = co[x].GetParameters();
            if(po.Length == 2) // matching constructor with two parameters // Also: check for 1
                break; // Note
        }

        if(x==co.Length)
        {
            Console.WriteLine("No matching constructor found");
            return; // Note
        }
        else
            Console.WriteLine("Two-parameter constructor found");

     
        object[] constructorargs = new object[2]; // Also: check for 1
        constructorargs[0] = 10;
        constructorargs[1] = 20; // 
        object mc = co[x].Invoke(constructorargs);

       //**************************************************************         
        
        MethodInfo[] mo = t.GetMethods();
    
        foreach(MethodInfo m in mo)
        {
            ParameterInfo[] po = m.GetParameters();
            
            if((m.Name.CompareTo("setMethod")==0) && (po[0].ParameterType==typeof(int)))
            {
                object[] args = new object[2];
                args[0] = 9;
                args[1] = 18;
                m.Invoke(mc, args);
            }

            if((m.Name.CompareTo("setMethod")==0) && (po[0].ParameterType==typeof(double)))
            {
                object[] args = new object[2];
                args[0] = 1.12D;
                args[1] = 23.4D;
                m.Invoke(mc, args);
            }

            if(m.Name.CompareTo("isBetweenMethod")==0)
            {
                object[] args = new object[1];
                args[0] = 14;
                if ((bool) m.Invoke(mc, args))
                    Console.WriteLine("14 is between x and y");
                else
                    Console.WriteLine("14 is not between x and y");
            }
               
            if(m.Name.CompareTo("additionMethod")==0)
            {
                Console.WriteLine("addition = {0}", ((int) m.Invoke(mc, null)));
            }
               
            if(m.Name.CompareTo("printMethod")==0)
            {
                m.Invoke(mc, null);
            } 
        }
    }
}
      

    

    