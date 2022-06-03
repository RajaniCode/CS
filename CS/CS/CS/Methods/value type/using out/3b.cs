// passing by reference


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

    public void myMethod(ref int ap, ref int bp)
    {
        ap = x;
        bp = y;
    }
}

class MainClass
{
    static void Main()
    {
        int a = 0; // Note: difference between 'ref' and 'out'
        int b = 0; // Note: difference between 'ref' and 'out'

        MyClass mc = new MyClass(5, 6);

        mc.myMethod(ref a, ref b);
    
        Console.WriteLine("a = {0}, b = {1}", a, b);
    }
}
        