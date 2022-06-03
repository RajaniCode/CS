// using out on reference 


using System;

class MyClass
{
    public int a;
    public int b;

    public MyClass() // Note
    {

    }

    public MyClass(int k, int l)
    {
        a = k;
        b= l;
    }
 
    public void printMethod()
    {
        Console.WriteLine("printMethod: a = {0}, b = {1}", a, b);
    }

    public void swapMethod(out MyClass mcp1, out MyClass mcp2)
    {
        MyClass t; 

        mcp1 = new MyClass(1, 2); // Note
        mcp2 = new MyClass(3, 4); // Note
        
        mcp1.printMethod(); // Note
        mcp2.printMethod(); // Note

        Console.WriteLine();

        t = mcp1;
        mcp1 = mcp2;
        mcp2 = t;
    }
}

class MainClass
{
    static void Main()
    {
	MyClass mc = new MyClass(); // Note

        MyClass mc1; // Note
        MyClass mc2; // Note     


        mc.swapMethod(out mc1, out mc2); 

        mc1.printMethod();
        mc2.printMethod();
    }
}

        



    
  

