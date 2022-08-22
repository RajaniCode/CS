// interface // interface cannot have static members

// interface methods implemented by class along with the class' own method


using System;

interface InterfaceExample 
{
    int nextMethod();
    void resetMethod();
    void fromMethod(int f);    
}

class MyClass
{
    int initial = 0;
    int result = 0;
    int previous = -2;

    public int nextMethod()
    {   
        // previous = result;
        result += 2;
        return result;
    }
 
    public void resetMethod()
    {
        result = initial;
        previous = initial - 2; 
    }

    public void fromMethod(int f)
    {
        initial = f;
        result = initial;
        previous = result - 2; // initial -2
    }

    // This method is not specified by the interface but by the class
    public int previousMethod()
    {
        return previous;
    }
}

class MainClass
{
    static void Main()
    {
        MyClass mc = new MyClass();
        
        Console.WriteLine("previous = " + mc.previousMethod());
        Console.WriteLine();

        for(int i=0; i<5; i++)
             Console.WriteLine(mc.nextMethod());
        Console.WriteLine();        
        

        

        Console.WriteLine("Resetting");
        mc.resetMethod(); 

        Console.WriteLine("previous = " + mc.previousMethod());
        Console.WriteLine();

        for(int i=0; i<5; i++)
             Console.WriteLine(mc.nextMethod());
        Console.WriteLine();   
       
        


        Console.WriteLine("From 100");
        mc.fromMethod(100); // Note
    
        Console.WriteLine("previous = " + mc.previousMethod());
        Console.WriteLine();

        for(int i=0; i<5; i++)
             Console.WriteLine(mc.nextMethod());
        Console.WriteLine();

       
    }
}




 