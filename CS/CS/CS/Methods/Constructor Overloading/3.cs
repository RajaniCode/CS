// Constructor Overloading

// ?Note: parameterless constructor [NEEDED if there is constructor overloading AND parameterless constructor call] 

// using this // one constructor invoking another // constructor with implied default arguments


using System;

class MyClass
{
    public int x; //Note
    public int y; //Note
   
    public MyClass() : this(0, 0)                 // invokes MyClass(int k, int l)
    {
        Console.WriteLine("Constructor MyClass()");
    }

    public MyClass(MyClass ob) : this(ob.x, ob.y) // invokes MyClass(int k, int l)
    {
        Console.WriteLine("Constructor MyClass(MyClass ob)");
    }

    public MyClass(int k, int l)
    {
        Console.WriteLine("Constructor MyClass(int x, int y)");
        x = k;
        y = l;
    }
  
    public MyClass(int x) : this(x, x) // constructor with implied default arguments, which are not explicitly specified

    {
        Console.WriteLine("Constructor MyClass(int x)");
    }    
}

class MainClass
{
    static void Main()
    {
        MyClass mc1 = new MyClass();
        MyClass mc2 = new MyClass(6, 7);
        MyClass mc3 = new MyClass(mc2);
        MyClass mc4 = new MyClass(8, 9);   

        Console.WriteLine("x = {0}, y = {1}", mc1.x, mc1.y);
        Console.WriteLine("x = {0}, y = {1}", mc2.x, mc2.y);
        Console.WriteLine("x = {0}, y = {1}", mc3.x, mc3.y);
        Console.WriteLine("x = {0}, y = {1}", mc4.x, mc4.y);
    }
}