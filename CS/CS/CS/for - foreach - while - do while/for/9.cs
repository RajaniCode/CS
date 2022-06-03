// for


using System;

class MyClass
{

    public int methodCommonMultiple(int a, int b)
    {
        int n;
        for(n=1;;n++) // NOTE
        {
  	    if(n%a == 0 && n%b == 0)
  	        return n;
        }
    }
}

class MainClass
{
    static void Main()
    {
        MyClass mc = new MyClass();

        int lcm;

        lcm = mc.methodCommonMultiple(9, 9);
        Console.WriteLine("The lcm of 9 and 9 is: {0}", lcm);


        lcm = mc.methodCommonMultiple(3, 9);
        Console.WriteLine("The lcm of 3 and 9 is: {0}", lcm);


        lcm = mc.methodCommonMultiple(6, 9);
        Console.WriteLine("The lcm of 3 and 9 is: {0}", lcm);  
    }
}