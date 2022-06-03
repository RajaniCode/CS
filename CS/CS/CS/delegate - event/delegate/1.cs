// delegate referring to static method(s)


using System;

delegate string MyDelegate(string str); // delegate with return type string

class MyClass
{   
    public static string replaceMethod(string a) // The method's return type should match with that of the delegate
    { 
        Console.WriteLine("Replacing spaces with hyphens in the string");
        return a.Replace(' ', '-'); 
    }
    

    public static string removeMethod(string a) // The method's return type should match with that of the delegate
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
     
    public static string methodSplit(string a) // The method's return type should match with that of the delegate
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
    
    public static string methodLength(string a) // The method's return type should match with that of the delegate
    {
        Console.WriteLine("Length of the string");
        return  a.Length.ToString(); // Note: a.Length is integral type, therefore convert to string
    }
    

    public static string methodTrim(string a) // The method's return type should match with that of the delegate
    {
        Console.WriteLine("Trimming the string");
        return  a.Trim(' '); // Note: Trims either on the right or the left of the string
    }
}

class MainClass
{
    static void Main()
    {
        string s; 
        
        MyDelegate md = new MyDelegate(MyClass.replaceMethod); // Note: class is NOT NEEDED in case of same class; no parenthesis for the method
        s = md("This is the string");
        Console.WriteLine("The string replaced is: {0} \n", s);

        md = new MyDelegate(MyClass.removeMethod); // Note: class is NOT NEEDED in case of same class; no parenthesis for the method
        s = md("This is the              string");
        Console.WriteLine("The string with spaces removed is: {0} \n", s);

        md= new MyDelegate(MyClass.methodLength); // Note: class is NOT NEEDED in case of same class; no parenthesis for the method
        s = md("This is the string");
        Console.WriteLine("The length of the string is: {0} \n", s);

        md = new MyDelegate(MyClass.methodSplit); // Note: class is NOT NEEDED in case of same class; no parenthesis for the method
        s = md("This  is   the                        string");
        Console.WriteLine("The string with multiple spaces trimmed to a single space is: {0} \n", s); 

        md = new MyDelegate(MyClass.methodTrim); // Note: class is NOT NEEDED in case of same class; no parenthesis for the method
        s = md("          This this the string        ");
        Console.WriteLine("The trimmed string is: {0} \n", s);
    }
}