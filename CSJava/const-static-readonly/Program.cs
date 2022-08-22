using static System.Console;

public class Program 
{
    public static readonly string constant = Unchangable();
    
    static Program() 
    {
        constant = "static readonly changable in static constructor";
    }

    public static string Unchangable() 
    {
        const string local = "Yo dude!";
        return local;
    }

    public static string GetConstant() 
    {
        return constant;
    }

    public static void Main() 
    {
	WriteLine(GetConstant());
    }
}