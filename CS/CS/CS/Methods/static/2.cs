// static field used to count instances // Also: static public

using System;

class MyClass
{
    static int count = 0;

    public MyClass()
    {
        count++;
    }

    ~MyClass()
    {
        count--;
    }

    public static int myMethod()
    {
        return count;
    }
}

class MainClass
{
    static void Main()
    {   
        MyClass mc; // Note
        for(int i=0; i<10; i++)
        {
            mc = new MyClass(); // Note
            Console.WriteLine("Instance: {0}", MyClass.myMethod()); 
        }
    }
}
        


 