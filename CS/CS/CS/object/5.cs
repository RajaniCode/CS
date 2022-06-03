// object class // object a universal data type

using System;

class MainClass
{
    static void Main()
    {
        object[] ob = new object[12];

        for(int i=0; i<3; i++)
            ob[i] = i;

        for(int i=3; i<6; i++)
            ob[i] = (int)i/2;

        ob[6] = "string";

        ob[7] = 'c';

        ob[8] = true;
     
        ob[9] = DateTime.Now.ToLongDateString() + "\0" + DateTime.Now.ToLongTimeString();

        ob[10] = DateTime.Now.ToLongDateString() + '\0' + DateTime.Now.ToLongTimeString();

        ob[11] = DateTime.Now.ToLongDateString() + null + DateTime.Now.ToLongTimeString();

        
        for(int i=0; i<ob.Length; i++)
            Console.WriteLine("ob[{0}] = {1}", i, ob[i]);
    }
}
   
        
          