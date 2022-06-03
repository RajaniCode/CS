// object class // boxing makes it possible to call methods on a value since all types are derived from object class, they all have access to its methods


using System;

class MyClass
{
    static void Main()
    {
        Console.WriteLine(10.1.ToString()); 
        Console.WriteLine((-10.1).ToString());
        Console.WriteLine("string".ToString());
        Console.WriteLine('c'.ToString());
        Console.WriteLine(true.ToString()); 
        Console.WriteLine("7/26/2007".ToString());

        Console.WriteLine();

        Console.WriteLine("Date");
        Console.WriteLine(DateTime.Now.Date.ToString()); 
        Console.WriteLine(DateTime.Now.Month.ToString());
        Console.WriteLine(DateTime.Now.Day.ToString());
        Console.WriteLine(DateTime.Now.Year.ToString());
        Console.WriteLine(DateTime.Now.DayOfWeek.ToString());
        Console.WriteLine(DateTime.Now.DayOfYear.ToString());

        Console.WriteLine();

        Console.WriteLine("Time");
        Console.WriteLine(DateTime.Now.TimeOfDay.ToString());
        Console.WriteLine(DateTime.Now.Hour.ToString()); 
        Console.WriteLine(DateTime.Now.Minute.ToString());
        Console.WriteLine(DateTime.Now.Second.ToString());
        Console.WriteLine(DateTime.Now.Millisecond.ToString());

        Console.WriteLine();

        Console.WriteLine(DateTime.Now.ToLongDateString());
        Console.WriteLine(DateTime.Now.ToLongTimeString());
    }
}
 