using System;

class MainClass
{      

    static void Main()
    {
        getDbl();       
    }

    static void getDbl()
    {
       
       bool flag = false;        
       
       do
       {
           string input = Console.ReadLine();
           
                for (int i = 0; i < input.Length; i++) 
                {
                  
                   if(input == ".") 
                       break;

                   if(input[i] < 46 || input[i] > 57)
                       break;

                   if(input[i] >= 48 && input[i] <= 57 || input[i] == 46) 
                       if(i == input.Length-1)
                           flag = true;                
               
                }
            

            switch(flag)
            {
                case false:
                    Console.WriteLine("Enter double");
                    break;
                case true:
                    Console.WriteLine("Quitting");
                    break;                
            }
        }while(flag != true);
     }
}