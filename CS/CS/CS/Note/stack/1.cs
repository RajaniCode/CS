// Stack


using System;

class MyClass
{
    char[] array;
    int last;

    public MyClass(int size)
    {
        array = new char[size];
        last = 0;
    }

    public void addMethod(char ch)
    {
        if(last==array.Length)
        {
            Console.WriteLine("Stack full");
            return;                              //Note 
        }
        
        array[last] = ch;
        last++;
        Console.Write(ch + " ");
    }

    public char deleteMethod()
    {
        if(last==0)
        {
            Console.WriteLine("Stack empty");
            return (char) 0;       // Note
        }    

        last--;
        return array[last];
    }

         
    public bool fullMethod()
    {
        return last==array.Length;  // Note
    }


    public bool emptyMethod()
    {
        return last==0;             // Note
    }

    public int capacityMethod()
    {
        return array.Length;
    }

    public int totalMethod()
    {
        return last;
    }
}

class MainClass
{
    static void Main()
    {      
        char c;

        MyClass mc1 = new MyClass(10);
        MyClass mc2 = new MyClass(10);
        MyClass mc3 = new MyClass(26);
        
        for(int i=0; !mc1.fullMethod(); i++)
        {
            mc1.addMethod((char)('A' + i)); // Note: add (push)
        }

        if(mc1.fullMethod())
            Console.WriteLine("\nStack full\n"); 
    
        while(!mc1.emptyMethod())
        {
            c = mc1.deleteMethod();     // Note: delete (pop)
            Console.Write(c + " ");
        }
   
        if(mc1.emptyMethod())
            Console.WriteLine("\nStack empty\n"); 

        for(int i=0; !mc1.fullMethod(); i++)
        {
            mc1.addMethod((char)('A' + i));
        }

        if(mc1.fullMethod())
            Console.WriteLine("\nStack full\n"); 
    
        while(!mc1.emptyMethod())
        {
            c = mc1.deleteMethod(); // Note: pop
            mc2.addMethod(c);       // Note: push           
        }

        if((mc1.emptyMethod()) && (mc2.fullMethod()))
            Console.WriteLine("\nStack popped and pushed full\n");                

        while(!mc2.emptyMethod())
        {
            c = mc2.deleteMethod();     // Note
            Console.Write(c + " ");
        }
   
        if(mc2.emptyMethod())
            Console.WriteLine("\nStack empty\n");

        for(int i=0; !mc3.fullMethod(); i++)
        {
            mc3.addMethod((char)('A' + i));
        }

        if(mc3.fullMethod())
            Console.WriteLine("\nStack full\n");


        Console.WriteLine("Stack capacity: {0}", mc3.capacityMethod());
        Console.WriteLine("Stack total: {0}", mc3.totalMethod()); 
    }
}

        
    

         



        
  

           
 








        
