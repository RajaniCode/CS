// C# 2.0 Delegate Method Group Conversion 

// delegate referring to static method(s)


using System;

delegate string MyDelegate(string str); 

class MyClass
{   
    public static string replaceMethod(string a) 
    { 
        Console.WriteLine("Replacing spaces with hyphens in the string");
        return a.Replace(' ', '-'); 
    }
    

    public static string removeMethod(string a) 
    {
        Console.WriteLine("Removing spaces in the string");
        string temp = "";
        for(int i=0; i<a.Length; i++)
        {
            if(a[i] != ' ')
                temp += a[i];
        }
        return temp; 
    }
     
    public static string methodSplit(string a) 
    {
        Console.WriteLine("Replacing multiple spaces with a single space in the string");
        
        string temp = "";
        
        char[] separator = {' '}; 
      
        string[] parts = a.Split(separator);
       
        for(int i=0; i<parts.Length; i++)
        {
           if(parts[i] != "") 
           {   
               temp += parts[i];
               temp += " ";               
           }
        }
        return temp;
    }    
    
    public static string methodLength(string a) 
    {
        Console.WriteLine("Length of the string");
        return  a.Length.ToString(); 
    }
    

    public static string methodTrim(string a) 
    {
        Console.WriteLine("Trimming the string");
        return  a.Trim(' '); 
    }
}

class MainClass
{
    static void Main()
    {
        string s; 
        
        MyDelegate md = MyClass.replaceMethod; // Note: class is NOT NEEDED in case of same class; no parenthesis for the method
        s = md("This is the string");
        Console.WriteLine("The string replaced is: {0} \n", s);

        md = MyClass.removeMethod; // Note: class is NOT NEEDED in case of same class; no parenthesis for the method
        s = md("This is the              string");
        Console.WriteLine("The string with spaces removed is: {0} \n", s);

        md= MyClass.methodLength; // Note: class is NOT NEEDED in case of same class; no parenthesis for the method
        s = md("This is the string");
        Console.WriteLine("The length of the string is: {0} \n", s);

        md = MyClass.methodSplit; // Note: class is NOT NEEDED in case of same class; no parenthesis for the method
        s = md("This  is   the                        string");
        Console.WriteLine("The string with multiple spaces trimmed to a single space is: {0} \n", s); 

        md = MyClass.methodTrim; // Note: class is NOT NEEDED in case of same class; no parenthesis for the method
        s= md("          This this the string        ");
        Console.WriteLine("The trimmed string is: {0} \n", s);
    }
}