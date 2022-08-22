// gcf, lcf and lcm


using System;

class MyClass
{
    public bool methodCommonFactor(int x, int y, out int gcfp, out int lcfp) // *Match: return type, bool
    {
        int i;         
        int limit;

        limit = x < y ? x : y; // Note: smallest of the two

        gcfp = 1;
        lcfp = 1;

        bool first = true;

        for(i=2; i<=(limit + 1); i++)
        {
            if((x%i==0) && (y%i==0))
            {
                if(first)
                {
                    lcfp = i;
                    first = false;
                }
                gcfp = i;
            }
        }
    
        if(lcfp != 1)
            return true;
        else
            return false;
    }

    public int methodCommonMultiple(int a, int b)
    {
        int n;
        for(n=1;;n++)
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
        int gcf;
        int lcf;

        MyClass mc = new MyClass();
                
        if(mc.methodCommonFactor(231, 105, out gcf, out lcf)) // *Match: type of the expression = return type of the method
        {
            Console.WriteLine("The gcf of 231 and 105 is = {0}", gcf);
            Console.WriteLine("The lcf of 231 and 105 is = {0}", lcf);
        }
        else
            Console.WriteLine("No common factor for the numbers");



        Console.WriteLine();

        if(mc.methodCommonFactor(9, 9, out gcf, out lcf)) // *Match: type of the expression = return type of the method
        {
            Console.WriteLine("The gcf of 9 and 9 is = {0}", gcf);
            Console.WriteLine("The lcf of 9 and 9 is = {0}", lcf);
        }
        else
            Console.WriteLine("No common factor for the numbers");

        Console.WriteLine();

        if(mc.methodCommonFactor(3, 9, out gcf, out lcf)) // *Match: type of the expression = return type of the method
        {
            Console.WriteLine("The gcf of 3 and 9 is = {0}", gcf);
            Console.WriteLine("The lcf of 3 and 9 is = {0}", lcf);
        }
        else
            Console.WriteLine("No common factor for the numbers");

        Console.WriteLine();

        int lcm;

        lcm = mc.methodCommonMultiple(9, 9);
        Console.WriteLine("The lcm of 9 and 9 is: {0}", lcm);


        lcm = mc.methodCommonMultiple(3, 9);
        Console.WriteLine("The lcm of 3 and 9 is: {0}", lcm);


        lcm = mc.methodCommonMultiple(6, 9);
        Console.WriteLine("The lcm of 3 and 9 is: {0}", lcm);  
    }
}