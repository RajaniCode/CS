// returning objects // using MyClass factory()

using System;

class MyClass
{
    int x;
    int y;
  
    public MyClass factory(int ip, int jp) // *Match return type, MyClass
    {
        MyClass mc = new MyClass();

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

        MyClass mc1 = new MyClass();
        MyClass mc2; // *Match: type, class
        
        for(i=0, j=10; i<10; i++, j--)
        {
            mc2 = mc1.factory(i, j); // *Match: type = return type 
            mc2.printMethod();
        }
    }
}