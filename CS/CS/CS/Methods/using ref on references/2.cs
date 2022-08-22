// using out on references

using System;

class MyClass
{
    int x;
    int y;
    
    public MyClass(int i, int j)
    { 
        x = i;
        y = j;
    }

    public void printMethod()
    {
        Console.WriteLine("printMethod: x = {0}, y = {1}", x, y);
    }

    public void assignMethod(out MyClass mcp1, out MyClass mcp2)
    {
        mcp1 = new MyClass(5, 6); // mcp1 sholud be assigned
        mcp2 = new MyClass(7, 8); // mcp1 sholud be assigned             
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

        mc1.assignMethod(out mc1, out mc2);
        
        mc1.printMethod();
        mc2.printMethod();
    }
}

    
    
    
     