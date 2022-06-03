// Difference when not using ref on reference 

// the ref modifier causes the reference itself to be passed by reference // allowing method to change the object to which the reference refers

using System;

class MyClass
{
    public int x;
    public int y;

    public MyClass(int i, int j)
    {
        x = i;
        y= j;
    }
 
    public void printMethod()
    {
        Console.WriteLine("printMethod: x = {0}, y = {1}", x, y);
    }

    public void notSwapMethod(MyClass mcp1, MyClass mcp2)
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

	Console.WriteLine();

        mc1.notSwapMethod(mc1, mc2);

        mc1.printMethod();
        mc2.printMethod();
    }
}

        



    
  

