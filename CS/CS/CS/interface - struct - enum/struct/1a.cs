// struct // static

using System;

struct MyStruct
{
    public static string author;
    public static string title;
    public static int copyright;

    public MyStruct(string a, string t, int c)
    {
        author = a;
        title = t;
        copyright = c;
    }

    public MyStruct(string t)
    {
        
        title = t;
       
    }
}

class MainClass
{
    static void Main()
    {
        MyStruct ms1 = new MyStruct("Her1b Schildt", "C#: Complete Reference", 2005);
        
        Console.WriteLine(MyStruct.title + " by " + MyStruct.author + ", (c) " + MyStruct.copyright);

        MyStruct ms2 = new MyStruct("Java Complete Reference"); // *Note 

        /*MyStruct ms3;

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

        ms3.title = "VC# Complete Reference"; */
        Console.WriteLine(MyStruct.title); 
    }
} 
        
        