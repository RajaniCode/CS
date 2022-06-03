// goto stop // stop not a keyword


using System;

class MainClass
{
    static void Main()
    {
        int i = 0, j = 0, k = 0; // remember, declare outside and also initialize
        for(i = 0; i < 5; i++)
            for(j = 0; j < 5; j++)    
                for(k = 0; k < 5; k++)
               { //
                    Console.WriteLine("i = {0}, j = {1}, k ={2}", i, j, k);
                    if(k == 3) goto stop; //
              } //
        stop: //
        Console.WriteLine("Stopped! " + "i = {0}, j = {1}, k ={2}", i, j, k);  //
    }
}
