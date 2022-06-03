// using ref on reference 

// the ref modifier causes the reference itself to be passed by reference // allowing method to change the object to which the reference refers


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

    public void swapMethod(ref MyClass mcp1, ref MyClass mcp2)
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

        mc1.swapMethod(ref mc1, ref mc2);

        mc1.printMethod();
        mc2.printMethod();
    }
}

        



    
  

