// out parameter // used to pass a value out of a method 


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

    public void myMethod(out int ap, out int bp)
    {
        ap = x;
        bp = y;
    }
}

class MainClass
{
    static void Main()
    {
        int a; // Note: difference between 'ref' and 'out'
        int b; // Note: difference between 'ref' and 'out'

        MyClass mc = new MyClass(5, 6);

        mc.myMethod(out a, out b);
    
        Console.WriteLine("a = {0}, b = {1}", a, b);
    }
}
        