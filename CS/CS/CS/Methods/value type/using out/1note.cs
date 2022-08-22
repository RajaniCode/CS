// out parameter // used to pass a value out of a method //*Note

// NOTE: Difference between ref and out


using System;

class MyClass
{    
    public int myMethod(double number, ref double bp) // *Match: return type, int
    {
       int i;
       i = (int)number;
       bp = number - i;

       return i;
    }
}

class MainClass
{
    static void Main()
    {
        int a; // *Match: type, int
        double b = 0; // NOTE: Difference between ref and out

        MyClass mc = new MyClass();
        a = mc.myMethod(10.125, ref b); // *Match: type of the variable = return type of the method

        Console.WriteLine("The integer part is: {0}", a);  // a from return i
        Console.WriteLine("The fraction part is: {0}", b); 
    }
}
        

             
