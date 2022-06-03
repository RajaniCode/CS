// reference type parameter


using System;

class MyClass
{
    public int a;
    public int b;

    public MyClass(int k, int l)
    {
        a = k;
        b= l;
    }
 
    public void printMethod()
    {
        Console.WriteLine("printMethod: a = {0}, b = {1}", a, b);
    }

    public void swapMethod(MyClass mcp1, MyClass mcp2)
    {
        MyClass t; // Note

        t = mcp1;
        mcp1 = mcp2;
        mcp2 = t;
    }
}

class MainClass
{
    static void Main()
    {
        MyClass mc1 = new MyClass(1, 2);
        MyClass mc2 = new MyClass(3, 4);
     
        mc1.printMethod();
        mc2.printMethod(); 

        mc1.swapMethod(mc1, mc2); // Note: Will not swap

        mc1.printMethod();
        mc2.printMethod();
    }
}

        



    
  

