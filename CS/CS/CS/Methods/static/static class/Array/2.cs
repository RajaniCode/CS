// Array in static // LOCAL

// array assignment example: object[] array = new object[]{1}; // object[] array = {1}; [ONLY AT DECLARATION]

// array element assignment example: array[0] = 1; (no curly braces) 
// [array size should be set before element assignment (otherwise: System.NullReferenceException) AND the array index should be less than the size]
// [array size re-defined can be changed ONLY using new]

// Array and const array can be LOCAL (without access specifiers and member modifiers) [ONLY inside static method in static class]
// const array regardless of type can only be assigned nulland ONLY AT DECLARATION AND const array element assignment is ALSO NOT POSSIBLE anywhere
// readonly array (static/instance) cannot be assigned outside declaration and constructors BUT readonly array element assignment is POSSIBLE anywhere


using System;

using System.Collections;

static class MainClass // can be static
{
    static void Main()
    {
        // int[] a = { 5, 10, 15 }; // ONLY DURING DECLARATION

        
        // int[] a;

        // a = new int[] {5, 10, 15}; // a = new int[3] { 5, 10, 15 }; // INVALID: a = new int[4] { 5, 10, 15 }; // INVALID: a = new int[2] { 5, 10, 15 };  

        // INVALID: int y = 3; int[] a; a = new int[y] { 5, 10, 15 }; 

        
        // int[] a; a = new int[3]; // POSSIBLE without assignment // array index should be less than 3

        // int y = 3; int[] a; a = new int[y]; // POSSIBLE ONLY without assignment // POSSIBLE ONLY in case of LOCAL (inside static/instance method) // array index should be less than y        
         
         
        // int[] a  = new int[] { 5, 10, 15 }; // int[] a = new int[3] { 5, 10, 15 }; // INVALID: int[] a = new int[4] { 5, 10, 15 }; // INVALID: int[] a = new int[2] { 5, 10, 15 };     

        // INVALID: int y = 3; int[] a = new int[y] { 5, 10, 15 };

    
        // int[] a = new int[3]; // POSSIBLE without assignment // array index should be less than 3

        int y = 3; int[] a = new int[y]; // POSSIBLE ONLY without assignment  // POSSIBLE ONLY incase of LOCAL (inside static/instance method) AND INSIDE CONSTRUCTOR // array index should be less than y    
        
        a[0] = 5; a[1] = 10; a[2] = 15; // element assignment 


        // INVALID: int[] a; a = new int[];

        // INVALID: int[] a = new int[];
        

        //int x = 2; int[][] b = new int[x][];
        int[][] b = new int[2][];
        b[0] = new int[3];
        b[1] = new int[4];
        
        bool[][] c = new bool[3][];
        c[0] = new bool[3];
        c[1] = new bool[2];
        c[2] = new bool[1];
        
        double[,] d = new double[2, 3];
               
        string[] e = new string[3]; 

        string note;

        char[] f = { '#', '1', 'A' };

        Console.WriteLine("a[0] = {0}, a[1] = {1}, a[2] = {2} \n", a[0], a[1], a[2]);
        
        b[0][0] = 1;
        b[0][1] = 2;
        b[0][2] = 3;
        Console.WriteLine("b[0][0] = " + b[0][0] + "\n" + "b[0][1] = " + b[0][1] + "\n" + "b[0][2] = " + b[0][2] + "\n");
        b[1][0] = 1;
        b[1][1] = 2;
        b[1][2] = 3;
        b[1][3] = 4;
        Console.WriteLine("b[1][0] = " + b[1][0] + "\n" + "b[1][1] = " + b[1][1] + "\n" + "b[1][2] = " + b[1][2] + "\n" + "b[1][3] = " + b[1][3] + "\n");
        
        c[0][0] = true;
        c[0][1] = false;
        c[0][2] = true;
        c[1][0] = false;
        c[1][1] = true;
        c[2][0] = false;
        Console.WriteLine("c[0][0]: {0} \nc[0][1]: {1} \nc[0][2]: {2} \nc[1][0]: {3} \nc[1][1]: {4} \nc[2][0]: {5}",
        c[0][0], c[0][1], c[0][2], c[1][0], c[1][1], c[2][0] + "\n");

        d[0, 0] = 7.147;
        d[0, 1] = -7.157;
        d[0, 2] = 2.8765;
        d[1, 0] = -2.117;
        d[1, 1] = 6.00138917;
        d[1, 2] = -6.55;
        Console.WriteLine("d[0, 0]: {0}  \nd[0, 1]: {1} \nd[0, 2]: {2} \nd[1, 0]: {3} \nd[1, 1]: {4} \nd[1, 2]: {5} \n", d[0, 0], d[0, 1], d[0, 2], d[1, 0], d[1, 1], d[1, 2]);

        e[0] = "Joe1";
        e[1] = "Matt";
        e[2] = "Robert";
        Console.WriteLine("e[0]: {0}, e[1]: {1}, e[2]: {2} \n", e[0], e[1], e[2]);
        
        note = "note is not declared as an array; but it is declared simply a string, which means it is an array of characters";
        Console.WriteLine("note: {0} \n", note);
        Console.WriteLine("note[0]: {0} \n", note[0]);
        Console.WriteLine("The first space in the string is note[4]: {0} \n", note[4]);
        Console.WriteLine("note[49]: {0} \n", note[49]);
        Console.WriteLine("note[50]: {0} \n", note[50]);
        Console.WriteLine("note[108]: {0} \n", note[108]);
        Console.WriteLine("note[109]: {0} \n", note[109]);
        Console.WriteLine("The last character of the string is note[note.Length -1]: {0} \n", note[note.Length -1]);
        Console.WriteLine("The length of the string is note.Length = {0} \n", note.Length);

        Console.WriteLine("f[0]: {0}, f[1]: {1}, f[2]: {2} \n", f[0], f[1], f[2]);

        //Arrays as Objects
        double[, ,] g = new double[2, 3, 5];
        Console.WriteLine("The length of the array is {0}.  \n", g.Length);

        int[, ,] h = new int[5, 10, 3];
        Console.WriteLine("The array has {0} dimensions. \n", h.Rank);

        //DateTime startDate = DateTime.Parse("06/23/2007");

        //DateTime startDate = DateTime.Parse("06/23/" + DateTime.Now.Year.ToString());

        //DateTime startDate = DateTime.Parse("06/" + DateTime.Now.Day.ToString() + "/" + DateTime.Now.Year.ToString());

        //DateTime startDate = DateTime.Parse(DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString() + "/" + DateTime.Now.Year.ToString());

        //DateTime startDate = DateTime.Parse("00:00");

        //DateTime startDate = DateTime.Parse(DateTime.Now.Millisecond.ToString());

        //DateTime startDate = DateTime.Parse(DateTime.Now.Second.ToString());

        //DateTime startDate = DateTime.Parse(DateTime.Now.Minute.ToString());

        //DateTime startDate = DateTime.Parse(DateTime.Now.Hour.ToString());
        
         
        
        //DateTime startDate = DateTime.Parse(DateTime.Now.TimeOfDay.ToString());

        DateTime startDate = DateTime.Parse(DateTime.Now.Date.ToString());

        ArrayList dates = new ArrayList();
        for (int i = 1; i <= 10; i++)
        {
            dates.Add(startDate.AddDays(i));            
        }

        DateTime[] dateArray = new DateTime[dates.Count];
        dates.CopyTo(dateArray);
        for (int j = 0; j < dates.Count; j++)
        {
            Console.WriteLine(dateArray[j]);
        }       
    }
}