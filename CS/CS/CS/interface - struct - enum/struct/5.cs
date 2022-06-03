// struct

using System;

struct MyStruct
{
    public string author; 
    public string title; 
    public int copyright;
    public int price;

    public MyStruct(string a, string t, int c) : this() // Note
    {
        author = a;
        title = t;
        copyright = c;
    } 

    public MyStruct(int p) : this() // Note
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
              
        Console.WriteLine(ms1.title + " by " + ms1.author + ", (c) " + ms1.copyright + " Rs." + ms2.price);        
    }
} 
        
        