// returning objects // static method // Also: static public

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

    public void printMethod()
    {
        Console.WriteLine("printMethod: x = {0}, y = {1}", x, y);
    }    

    public int areaMethod()
    {
        return x * y;
    }    
        
    public static MyClass enlargeMethod(MyClass mcp, int fp) //*Match: return type, MyClass // static
    {
        return new MyClass(mcp.x * fp, mcp.y * fp); // Note
    }
}

class MainClass
{
    static void Main()
    {
        int f = 10;
 
        MyClass mc1 = new MyClass(5, 6);

        mc1.printMethod();
        Console.WriteLine("Area = {0}", mc1.areaMethod());
  
        MyClass mc2; //*Match: type, MyClass
        mc2 = MyClass.enlargeMethod(mc1, f); //*Match: type = return type // static
       
        mc2.printMethod(); // Note: mc2 has f
        Console.WriteLine("Area = {0}", mc2.areaMethod());
    }
}