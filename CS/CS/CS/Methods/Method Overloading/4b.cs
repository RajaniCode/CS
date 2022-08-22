// Method Overloading // instance method // Note: return type difference is not enough


using System;

class MyClass
{
    public void myMethod(int a)
    {
        Console.WriteLine("Parameter int: a = {0}", a);
    }

    public void myMethod(double a)
    {
        Console.WriteLine("Parameter double: a = {0}", a);
    }
}


class MainClass
{
    static void Main()
    {
        MyClass mc = new MyClass();
    
        Console.WriteLine("# 1"); 
        sbyte sb = -1;
        mc.myMethod(sb);
         
        Console.WriteLine("# 2");
        byte b = 0;
        mc.myMethod(b);
         
        Console.WriteLine("# 3"); 
        short s = -1;
        mc.myMethod(s);
         
        Console.WriteLine("# 4"); 
        ushort us = 2;
        mc.myMethod(us);
               
        Console.WriteLine("# 5");
        int i = -3;
        mc.myMethod(i);
          
        Console.WriteLine("# 6"); 
        uint ui = 4;
        mc.myMethod(ui);
        
        Console.WriteLine("# 7");
        long ln = -5;
        mc.myMethod(ln);
        
        Console.WriteLine("# 8");
        ulong uln = 6;
        mc.myMethod(uln);
        
        Console.WriteLine("# 9");
        float ft = -7.0F;
        mc.myMethod(ft);
         
        Console.WriteLine("# 10"); 
        double db = -8.0;
        mc.myMethod(db);          
    }
}