// for


using System;

class MainClass
{
    static void Main()
    {
        int i;
        int j; //
        Console.WriteLine("Enter the string:");
        string a = Console.ReadLine();
        string temp = ""; // Note initial assignment
        for(j=0, i=a.Length-1; i >=0; i--, j++) // for(i=a.Length-1; i >=0; i--)
            temp += a[i];
        Console.WriteLine("The reversed string is: {0}", temp); // Also: Console.Write as you are printing once and temp is a string (charcter array)
    }    
}        