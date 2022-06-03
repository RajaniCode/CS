// struct

using System;

struct MyStruct
{
    public string author; // Note: cannot have instance field initializers in structs
    public string title;
    public readonly int copyright;
    public const int price = 525;

    public MyStruct(string a, string t, int c) 
    {
        author = a;
        title = t;
        copyright = c;
    }   
}

struct MainClass
{
    static void Main()
    {
        MyStruct ms = new MyStruct("Her1b Schildt", "C#: Complete Reference", 2005);      
              
        Console.WriteLine(ms.title + " by " + ms.author + ", (c) " + ms.copyright + " Rs." + MyStruct.price);        
    }
} 
        
        