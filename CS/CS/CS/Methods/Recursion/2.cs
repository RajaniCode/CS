// Recursion // Reversing string


using System;

class MyClass
{
    public void myMethod(string s)
    {
       if(s.Length>0)
           myMethod(s.Substring(1, s.Length-1));               
       else
           return; 
        
       Console.Write(s[0]);
                      
    }
}

class MainClass
{
    static void Main()
    {
        Console.WriteLine("Enter string:");
        string str = Console.ReadLine(); 

        MyClass mc = new MyClass();       

        mc.myMethod(str); 

        // Console.WriteLine("\n" + str); // Note: passing by value;
           
    }
}    
        
         