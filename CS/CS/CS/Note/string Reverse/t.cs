// string array with each string in alphabetical or ascending order


using System;

class MainClass
{
    static void Main()
    {
        string s = string.Empty;       
            
        Console.WriteLine("Enter string:");  
            s = Console.ReadLine();
     
        Console.WriteLine("The string reverse is:");              

        char[] array = new char[s.Length];
          
        for(int i=0; i<s.Length; i++)
            array[i] = s[i];
    
        char[] t = new char[s.Length];
               
        for(int k = 0; k < array.Length; k++) 
        {
            for(int l = 0 ;l < array.Length-1; l++) 
            {
                if(array[l] > array[l + 1])
                {
                    t[l] = array[l];
                    array[l] = array[l+1];
                    array[l+1] = t[l];
                }
            }
        }

        for(int m=0; m<array.Length; m++)  // for(int m=array.Length-1;m>=0;m--)   // reverse alphabetical or descending order
            Console.Write(array[m]); 

        Console.WriteLine();
    }  
}