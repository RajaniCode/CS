// returning array // using 'out'

using System;

class MyClass
{
    public int[] myMethod(int number, out int nooffactors) // *Match: return type, int[]
    {
        int i;
        int j;

        int[] factor = new int[80];

        for(i=2, j =0; i<((number/2) +1); i++)
            if(number%i==0)
            {
                factor[j] = i;
                j++;
            
            }
        nooffactors = j;
        return factor;   // Note                           
    }
}

class MainClass
{
    static void Main()
    {
        int[] f; // *Match: type, int[]
        int nf;
         
        MyClass mc = new MyClass();
        
        f = mc.myMethod(1000, out nf); // *Match: type = return type

        for(int i=0; i<nf; i++)
        {
            Console.Write(f[i] + " ");
        }
    }
}


          