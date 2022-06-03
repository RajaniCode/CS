// Inheritance - Constructor Overloading // 3, 4, 8


// 1. base() corresponds parameterless BaseClass constructor

// 2. explicit base() NEED NOT have the corresponding explicit parameterless BaseClass constructor

// 3. 'parameterized base(<parameter*>)' MUST have the corresponding parameterized BaseClass constructor

// 4. Hence 'parameterized base(<parameter*>)' assigns BaseClass variables [even private (default)]


// 5. parameterless constructor [NEEDED if there is constructor overloading AND parameterless constructor call] 
// 6. parameterless constructor [NEEDED if there is BaseClass constructor overloading AND DerivedClass constructor overloading] BUT
//    7. parameterless constructor [NOT NEEDED ONLY if 'parameterized base(<parameter*>)' extends 
//       EVERY DerivedClass parameterized constructor AND if there is NO explicit DerivedClass parameterless constructor] THEREFORE
//       8. parameterless constructor [NEEDED if 'parameterized base(<parameter*>)' extends 
//          EVERY DerivedClass parameterized constructor BUT if there is EXPLICIT DerivedClass parameterless constructor]
//       9. parameterless constructor [NEEDED if 'parameterless base()' OR NOTHING extends EVERY DerivedClass parameterized constructor 
//          EVEN if there is NO EXPLICIT DerivedClass parameterless constructor]
// [EXPLICIT DerivedClass parameterless constructor may be prompted by DerivedClass constructor overloading AND 
//  DerivedClass parameterless constructor call, OR
//  if there is FurtherDerivedClass AND DerivedClass parameterless constructor call and so on] 
// 10. Note: parameter* is any variable(s) from the extended DerivedClass parameterized constructor's signature


using System;
 
class BaseClass
{
    string note;
    
    // Won't be invoked
    public BaseClass()
    {
	Console.WriteLine("\nBaseClass constructor invoked");
    }
 
    public BaseClass(string s) 
    {
        note = s;
        Console.WriteLine("\nBaseClass constructor invoked: " + note);     
    }
}

class DerivedClass : BaseClass
{
    string text;
      
    // Won't be invoked
    public DerivedClass()
    {
	Console.WriteLine("\nDerivedClass constructor invoked "); 
    }

    public DerivedClass(string s)  : base(s)
    {
        text = s;
        Console.WriteLine("\nDerivedClass constructor invoked: " + text);     
    }   
}

class MainClass
{
    static void Main()
    {
        BaseClass bc = new BaseClass("Invoking BaseClass constructor");         
        
        Console.WriteLine("\nNext");

        DerivedClass dc = new DerivedClass("Invoking DerivedClass constructor");             
    }       
}