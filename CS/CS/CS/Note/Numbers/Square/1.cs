using System;
using System.IO;

class MainClass
{
    public static void Main()
    {
        string path = @"file.txt";
        string s = "";
        float number = 0;
        // Open the file to read from.
        using (StreamReader sr = File.OpenText(path))
        {            
            while ((s = sr.ReadLine()) != null)
            {
                number = float.Parse(s);
            }
        }        

        // This text is added only once to the file.
        // This text is always added, making the file longer over time
        // if it is not deleted.
        using (StreamWriter sw = File.AppendText(path))
        {
            sw.WriteLine(" The square root of " + number + " is: " + squareroot(number));            
        }

        // Open the file to read from.
        
    }
    static float squareroot(float n)
    {
        float i = 0F;
        float x1 = 0F;
        float x2 = 0F;

        while ((i * i) <= n)
            i += 0.1F;
        x1 = i;

        for (int j = 0; j < 10; j++)
        {
            x2 = n;
            x2 /= x1;
            x2 += x1;
            x2 /= 2;
            x1 = x2;
        }
        return x2;
    }
}

