// params modifier // used to declare array parameter // variable length parameter

// value type, no constructor

// [method returns]

using System;

class MyClass
{
    public int minimumMethod(params int[] array) // *Match: return type, int
    {
        int m;        

        if(array.Length == 0)
        {
            Console.WriteLine("Error: no arguments");
            return 0;
        }

        m = array[0];
        for(int i=1; i<array.Length; i++)
            if(array[i] < m)
                m = array[i];

        return m;
                   
    }
}

class MainClass
{
    static void Main()
    {  
        int a = 5;
        int b = 6;
        
        int min; // *Match: type, int

        MyClass mc = new MyClass();

        min = mc.minimumMethod(a, b); // *Match: type of the variable = type of the method

        Console.WriteLine("The minimum value is = {0} \n", min);
        
        min = mc.minimumMethod(a, b, -7); // *Match: type of the variable = type of the method

        Console.WriteLine("The minimum value is = {0} \n", min);


        min = mc.minimumMethod(6, 7, -7, 9, -7); // *Match: type of the variable = type of the method

        Console.WriteLine("The minimum value is = {0} \n", min);

        int[] args = {55, 7 , -7 , -88, 10}; // Note
        min = mc.minimumMethod(args);        // *Match: type of the variable = type of the method
        Console.WriteLine("The minimum value is = {0} \n", min);
    }
}
     
      

        