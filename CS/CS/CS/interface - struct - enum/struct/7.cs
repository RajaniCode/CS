// struct

using System;

struct MyStruct
{
    public static string author;
    public static string title;
    public static int copyright;

    public string auth;
    public string tit;
    public int copyrig;

    public MyStruct(string a, string t, int c) // constructor
    {
        author = a;
        title = t;
        copyright = c;
        auth = "";   // Note
        tit = "";    // Note
        copyrig = 0; // Note
    }
  
    public MyStruct(int c, string a, string t) // constructor overloading
    {
        author = string.Empty;   // Note
        title = string.Empty;    // Note
        copyright = 0; // Note
        auth = a;
        tit = t;
        copyrig = c;
    }

    public static void staticMethod()
    {
        Console.WriteLine("staticMethod");
    }
 
    public void instanceMethod()
    {
        Console.WriteLine("instanceMethod");
    }
     
}

class MainClass
{
    static void Main()
    {
        MyStruct ms1 = new MyStruct("Herb Schildt", "C#: Complete Reference", 2005);
        Console.WriteLine(MyStruct.title + " by " + MyStruct.author + ", (c) " + MyStruct.copyright); 
        
        MyStruct ms2 = new MyStruct(2000, "Bjarne Straustrup", "C: Complete Reference");
        Console.WriteLine(ms2.tit + " by " + ms2.auth + ", (c) " + ms2.copyrig);  
    
        MyStruct.staticMethod();
    
        ms2.instanceMethod();
    }
} 
        
        