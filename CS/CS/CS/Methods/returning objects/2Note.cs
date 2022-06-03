// returning objects // using MyClass factory()

using System;

class MyClass
{
    int x;
    int y;
 
    public MyClass() // *Note2
    {
        x = 0;
        y = 0;
    }
    

    public MyClass(int k, int l) // *Note1
    {
        x = k;
        y = l;
    }
  
    public MyClass factory(int ip, int jp) // *Match return type, MyClass
    {
        MyClass mc = new MyClass(); // *Note2 and Note1

        mc.x = ip;
        mc.y = jp;
 
        return mc;
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
        int i;
        int j;

        MyClass mc1 = new MyClass(8, 8); // *Note1
        mc1.printMethod();
 
        MyClass mc2;
        for(i=0, j=10; i<10; i++, j--)
        {
            mc2 = mc1.factory(i, j); // *Match mc2 type, MyClass
            mc2.printMethod();
        }
    }
}