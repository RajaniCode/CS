using System;

class Program 
{
    void Method() 
    {
        throw new NotImplementedException("Missed to implement.");
    }

    static void Main() 
    {
        try 
        {
            Program prgm = new Program();
            prgm.Method();
	}
        catch(Exception ex)
        {
            // throw ex; // Unhandled Exception: System.NotImplementedException: Missed to implement. // at Program.Main()
            throw; // Unhandled Exception: System.NotImplementedException: Missed to implement. // at Program.Method() // at Program.Main()
        }
    }
}