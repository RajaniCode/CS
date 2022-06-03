// string array in alphabetical or ascending order


using System;

class MainClass
{
    static void Main()
    {   
        Console.WriteLine("Enter number of elements");
        int n = int.Parse(Console.ReadLine());

        string[] array = new string[n];
        
        Console.WriteLine("Enter string"); 
        for(int i=0; i<n; i++)
        {            
            array[i] = Console.ReadLine();
        }

        for(int i=0; i<array.Length; i++)
        {
            for(int j=0; j<array.Length-1; j++)             
                if(array[j].CompareTo(array[j+1]) == 1)
                {
                    string temp = array[j];
                    array[j] = array[j+1];
                    array[j+1] = temp;
                }
        }              

        Console.WriteLine("Array in alphabetical or ascending order is:");
        for(int i=0; i<array.Length; i++ )    // for(int i=array.Length-1; i>=0; i--)  // reverse alphabetical or descending order
        {
            Console.WriteLine(array[i] + " ");
        }                
    }
}

