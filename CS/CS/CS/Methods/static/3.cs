returning objects // using factory // static method // Also: static public

using System;

class MyClass
{
    public int x;
    int y;

    public void printMethod()
    {
        Console.WriteLine("x = {0}, y = {1}", x, y);
    }

    public static MyClass factory(int ip, int jp) //*Match: return type, MyClass // static
    {
        MyClass mc = new MyClass();

        mc.x = ip;
        mc.y = jp;

        return mc; 
    }        
}

class MainClass
{
    static void Main()
    {
        MyClass mc; //*Match: type, MyClass

        for(int i=0, j=10; i<10; i++, j--) // Note j also defined
        {
            mc = MyClass.factory(i, j); //*Match: type = return type // static
            mc.printMethod(); // factory and printMethod now related through mc
        }
    }
}  