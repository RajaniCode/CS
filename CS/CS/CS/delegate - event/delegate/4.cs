// delegate multicasting using static method(s) // ref


using System;

delegate void MyDelegate(ref string str);

class MyClass
{
    public static void methodReplace(ref string sp)
    {
        Console.WriteLine("Replacing space with hyphen");
        sp = sp.Replace(' ', '-');
    }  
     
    public static void methodRemove(ref string sp)
    {
        int i;
        int j;
        string temp ="";
        Console.WriteLine("Removing space");
        for(j=0, i=0; i<sp.Length; i++, j++)
        {
            if(sp[i] != ' ')
                temp += sp[i];
        }
        sp = temp;        
    } 

    public static void methodReverse(ref string sp)
    {
        string temp ="";
        Console.WriteLine("Reversing string");
        for(int i=sp.Length-1; i >=0; i--)
            temp += sp[i];
        sp = temp;        
    }
}

class MainClass
{
    static void Main()
    {
        MyDelegate md;

        MyDelegate mReplace = MyClass.methodReplace;
        MyDelegate mRemove = MyClass.methodRemove;
        MyDelegate mReverse = MyClass.methodReverse;


        string s = "This is the string1";
        
        // Set up Multicast // Add
        md = mReplace;
        md += mReverse;
        
        // Call Multicast
        md(ref s); 
        Console.WriteLine("The resulting string is: = {0} \n", s);

        
        
        // Set up Multicast // Remove and Add
        md -= mReplace; 
        md += mRemove; // On the Reset string // But mReverse remains
     
        s = "This is the string"; // Reset string
        
        // Call Multicast
        md(ref s);
        Console.WriteLine("The resulting string is: = {0} \n", s);
    }
}



 