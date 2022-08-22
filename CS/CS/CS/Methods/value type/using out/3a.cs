// passing by value 


using System;

class MyClass
{
    int x;
    int y;
 
    public MyClass(int k, int l)
    {
        x = k;
        y = l;
    }

    public void myMethod(int ap, int bp)
    {
        ap = x;
        bp = y;
    }
}

class MainClass
{
    static void Main()
    {
        int a = 0; // Note
        int b = 0; // Note

        MyClass mc = new MyClass(5, 6);

        mc.myMethod(a, b);
    
        Console.WriteLine("a = {0}, b = {1}", a, b);
    }
}
        