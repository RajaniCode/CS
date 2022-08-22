// using 'out'

using System;

class MyClass
{
    public void myMethod(int number, out int nooffactors) // *Match: return type, int[]
    {
        int i;
        int j;

        int[] factor = new int[80];

        for(i=2, j =0; i<=((number/2) +1); i++)
            if(number%i==0)
            {
                factor[j] = i;
                j++;
                Console.Write(i + " ");                                         
            }        
        nooffactors = j;                           
    }
}

class MainClass
{
    static void Main()
    {
        int nf;
        
        MyClass mc = new MyClass();        
        mc.myMethod(1000, out nf);
        
        Console.Write("\nNumber of factors = {0}", nf);         
    }
}


          