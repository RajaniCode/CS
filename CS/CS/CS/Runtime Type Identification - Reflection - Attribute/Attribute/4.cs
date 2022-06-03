// built-in attribute

// Conditional

#define TRIAL


using System;
using System.Diagnostics; // Note

class MainClass
{
    [Conditional("TRIAL")]
    void trial()
    {
        Console.WriteLine("Trial version");
    }
    
    [Conditional("RELEASE")]
    void release()
    {
        Console.WriteLine("Release version");
    }

    static void Main()
    {
        MainClass mc = new MainClass();
        
        mc.trial();
        mc.release(); // Note: will be bypassed because not defined via #define
    }
}