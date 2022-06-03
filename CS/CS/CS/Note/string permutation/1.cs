// string permutation


using System;

class MyClass
{
    string switchchars(string topermute, int x, int y)
    {
	string newstring = topermute;
        
        char[] t = new char[newstring.Length];

        for(int i=0; i<newstring.Length; i++)
            t[i] = newstring[i];

        char temp = ' ';
      
        temp = t[x];
	t[x] = t[y];
        t[y] = temp; 

        string str = "";

        for(int i=0; i<newstring.Length; i++)
            str += t[i];
     
	return str;
    }

    public void permute(string topermute, int place) // NOTE: A params parameter must be the last parameter in a formal parameter list
    {
	if(place == topermute.Length)
	{
		Console.WriteLine(topermute);
	}

	for(int nextchar = place; nextchar<topermute.Length; nextchar++)
	{
		permute(switchchars(topermute, place, nextchar), place+1);
	}
    }
}

class MainClass
{   
    static int Main(string[] args)  
    {
        MyClass mc = new MyClass();
        mc.permute(args[0], 0);

        return 0;
    }
}