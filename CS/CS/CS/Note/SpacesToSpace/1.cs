// SpacesToSpace


using System;
 
class MainClass
{
    static void Main()
    {
        int i = 0;
        int space = 0;

        Console.WriteLine("Enter string:");
        string s = Console.ReadLine();
        
        try
        {
            while(s[i] != '\0')
            {
                if(s[i] != ' ')
                {
                    space = 0;
                    Console.Write(s[i]);
                } 
                else
                {
                    if(s[i]==' ') 
                    {
                        space = space + 1;
                        if(space == 1)
                            Console.Write(' ');
                    }
                }
                i++;
            }
        }
        catch(Exception)
        {

        }        
    }    
}
