// struct

using System;

struct MyStruct
{
    public static string author = string.Empty; // Note: Only for static
    public  static  string title = string.Empty; 
    public static  int copyright = 0;
    public static  int price = 0;

    public MyStruct(string a, string t, int c) 
    {
        author = a;
        title = t;
        copyright = c;
    } 

    public MyStruct(int p) 
    {
        price = p; 
    }  
}

struct MainClass
{
    static void Main()
    {
        MyStruct ms1 = new MyStruct("Her1b Schildt", "C#: Complete Reference", 2005);      

        MyStruct ms2 = new MyStruct(525); 
              
        Console.WriteLine(MyStruct.title + " by " + MyStruct.author + ", (c) " + MyStruct.copyright + " Rs." + MyStruct.price);        
    }
} 
        
        