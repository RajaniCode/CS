// Collections // Stack // first-in last-out // last-in first-out


using System;
using System.Collections;

class MainClass
{   
    static void StatckPush(Stack st, int a)
    {
        st.Push(a);

        Console.WriteLine("Push(" + a + ")");
        
        Console.Write("Stack: "); 
        foreach(int i in st)
            Console.Write(i + " ");
            
        Console.WriteLine();
    }

    static void StatckPop(Stack st)
    {
        int a = (int)st.Pop();
       
        Console.Write("Pop - > ");        
        Console.Write(a);

 	Console.WriteLine();

        Console.Write("Stack: ");
        foreach(int i in st)
            Console.Write(i + " ");
            
        Console.WriteLine();

    }
   
    static void Main()
    {
         Stack st = new Stack();

         StatckPush(st, 22);
         StatckPush(st, 65);
	 StatckPush(st, 91);
         StatckPop(st);  
         StatckPop(st); 
         StatckPop(st);
    }
}
