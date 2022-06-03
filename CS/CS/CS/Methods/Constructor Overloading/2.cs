// Constructor Overloading

// ?Note: parameterless constructor [NEEDED if there is constructor overloading AND parameterless constructor call] 


using System;

class MyClass
{
    char[] array;
    int top;

    public MyClass(int size)
    {
        array = new char[size];
        top = 0;
    }

    public MyClass(MyClass ob) // constructor overloading 
    {
        array = new char[ob.array.Length];
        
        for(int i=0; i<ob.top; i++)  //
            array[i] = ob.array[i];  //      

        top = ob.top; 
    }

    public void addMethod(char ch)
    {
        if(top==array.Length)
        {
            Console.WriteLine("Stack full");
            return;
        }
        array[top] = ch;
        Console.Write(array[top] + " ");
        top++;        
    }

    public char deleteMethod()
    {
        if(top==0)
        {
            Console.WriteLine("Stack empty");
            return (char)0;
        }
        top--;
        return array[top];      
    }

    public bool fullMethod()
    {
        return top==array.Length;
    }
     
    public bool emptyMethod()
    {
        return top==0;
    }

    public int capacityMethod()
    {
        return array.Length;
    }

    public int totalMethod()
    {
        return top;
    }
}

class MainClass
{
    static void Main()
    {
        char c;

        MyClass mc1 = new MyClass(10);
        MyClass mc2 = new MyClass(mc1);// Note
        MyClass mc3 = new MyClass(26);

        for(int i=0; !mc1.fullMethod(); i++)
            mc1.addMethod((char)('A'+ i));


        if(mc1.fullMethod())
            Console.WriteLine("\nStack full \n");

        while(!mc1.emptyMethod())
        {
            c = mc1.deleteMethod();
            Console.Write(c + " ");
        }    
         
        if(mc1.emptyMethod())
            Console.WriteLine("\nStack empty \n");

        for(int i=0; !mc1.fullMethod(); i++)
            mc1.addMethod((char)('A'+ i));


        if(mc1.fullMethod())
            Console.WriteLine("\nStack full \n");


        while(!mc1.emptyMethod())
        {
            c = mc1.deleteMethod();
            mc2.addMethod(c);
        }    
         
        if((mc1.emptyMethod()) && (mc2.fullMethod()))
            Console.WriteLine("\nStack poppep and pushed full\n");

        while(!mc2.emptyMethod())
        {
            c = mc2.deleteMethod();
            Console.Write(c + " ");
        }    
         
        if(mc2.emptyMethod())
            Console.WriteLine("\nStack empty \n");
        
        for(int i=0; !mc3.fullMethod(); i++)
            mc3.addMethod((char)('A'+ i));


        if(mc3.fullMethod())
            Console.WriteLine("\nStack full \n");

        Console.WriteLine("Stack capacity = {0}", mc3.capacityMethod());
        Console.WriteLine("Stack total elements = {0}", mc3.totalMethod());             
    }
}
         
        




  
  
 