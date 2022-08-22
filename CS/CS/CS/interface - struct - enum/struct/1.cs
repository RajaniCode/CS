// struct

using System;

struct MyStruct  
{
    public string author;
    public string title;
    public int copyright;

    public MyStruct(string a, string t, int c) // constructor
    {
        author = a;
        title = t;
        copyright = c;
    }
}

class MainClass : object
{
    static void Main()
    {
        MyStruct ms1 = new MyStruct("Herb Schildt", "C#: Complete Reference", 2005);

        MyStruct ms2 = new MyStruct(); // *Note 

        MyStruct ms3;
        
        Console.WriteLine(ms1.title + " by " + ms1.author + ", (c) " + ms1.copyright);

        Console.WriteLine();

        if(ms2.title == null) // *Note 
            Console.WriteLine("ms2.title is null");

        Console.WriteLine();

        ms2.title = "Java Complete Reference";

        ms2.author = "James Gosling";

        ms2.copyright = 2005;
 
        Console.Write("m2 now contains: ");
        Console.WriteLine(ms2.title + " by " + ms2.author + ", (c) " + ms2.copyright);

        Console.WriteLine();

        ms3.title = "VC# Complete Reference"; 
        Console.WriteLine(ms3.title);
    }
} 
        
        