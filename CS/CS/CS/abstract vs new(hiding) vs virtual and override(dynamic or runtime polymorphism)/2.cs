// Overloading // Nothing to do with inheritance unlike Overriding


using System;

class OverloadingClass 
{
    public string overloadingMethod()     
    {
        return "virtualMethod() in abstract BaseClass"; 
    } 

    public string overloadingMethod(string str)     
    {
        return str; 
    }   

    internal static int overloadingMethod(int i) // Note: static     
    {
        return i; 
    }    
}


class MainClass : OverloadingClass 
{  

    static void Main()
    { 
         Console.WriteLine(MainClass.overloadingMethod(111));
         
         Console.WriteLine(OverloadingClass.overloadingMethod(222));  
         
         MainClass mc = new MainClass();

         Console.WriteLine(mc.overloadingMethod("argument passed to parameter"));       
    }
}




