// string array with each string in alphabetical or ascending order


using System;

class MainClass
{
    static void Main()
    {
        Console.WriteLine("Enter the number of strings:"); 
        int n = int.Parse(Console.ReadLine());
        
        string[] s = new string[n];       
            
        Console.WriteLine("Enter string(s):");  
        for(int i=0; i<n; i++)
            s[i] = Console.ReadLine();
     
        Console.WriteLine("The string array with each string in alphabetical or ascending order is:");              
        for(int i=0; i<n; i++) 
        {
            char[] array = new char[s[i].Length];
            
            for(int j=0;j<s[i].Length;j++)
                array[j] = s[i][j];
    
            char[] t = new char[s[i].Length];
               
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

            for(int m=0;m<array.Length;m++)  // for(int m=array.Length-1;m>=0;m--)   // reverse alphabetical or descending order
                Console.Write(array[m]); 

            Console.WriteLine();
        }
    }  
}