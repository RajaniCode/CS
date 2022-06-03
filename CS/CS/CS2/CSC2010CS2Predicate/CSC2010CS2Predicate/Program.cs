using System;

/*
C# 2.0 introduced a new feature: the predicate. A predicate is a delegate of type
System.Predicate that returns either true or false, based upon some condition.
The object to be tested against the condition is passed in obj. If obj satisfies that condition,
the predicate must return true. Otherwise, it must return false. Predicates are used by
several new methods added to Array by C# 2.0, including Exists( ), Find( ), FindIndex( ), and FindAll().
The following program demonstrates using a predicate to determine if an array of integers
contains a negative value. If a negative value is found, the program then obtains the first
negative value in the array. To accomplish this, the program uses Exists( ) and Find( ).
 */
class Predicates
{
    // A predicate method.
    // Returns true if Value is negative.
    bool IsNegative(int Value)
    {
        if (Value < 0)
        {
            return true;
        }
        return false;
    }

    public void Print()
    {
        int[] Numbers = { 1, 4, -1, 5, -9 };
        Console.Write("Contents of numbers: ");
        foreach (int i in Numbers)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();

        // First see if nums contains a negative value.
        if (Array.Exists(Numbers, IsNegative))
        {
            Console.WriteLine("Numbers contains a negative value.");

            // Now, find first negative value.
            int x = Array.Find(Numbers, IsNegative);
            Console.WriteLine("First negative value is: " + x);
        }
        else
        {
            Console.WriteLine("Numbers contains no negative values.");
        }
    }
}

class MainApp
{
    static void Main()
    {
        Predicates Predct = new Predicates();
        Predct.Print();

        Console.ReadKey();
    }
}

/* Output
Contents of numbers: 1 4 -1 5 -9
Numbers contains a negative value.
First negative value is: -1
*/