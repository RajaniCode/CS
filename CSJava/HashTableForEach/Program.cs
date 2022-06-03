using static System.Console;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

class Program
{
    public object FindKey(object Value, Hashtable Ht)
    {
        object Key = new object();
        IDictionaryEnumerator e = Ht.GetEnumerator();
        while (e.MoveNext())
        {
            if (e.Value == Value)
            {
               Key = e.Key;
            }
        }
        return Key;
    }


    private void Writer(object value) 
    {
        WriteLine("Value:{0}", value);
    }

    private void Method()
    {
        Hashtable names = new Hashtable();
        names.Add("Alpha", 1);
        names.Add("Beta", 2);
        names.Add("Gamma", 3);
        names.Add("Delta", 4);
        names.Add("Epsilon", 5);
        // Unhandled Exception: System.ArgumentNullException: Key cannot be null. 
        // Unhandled Exception: System.ArgumentException: Item has already been added. Key in dictionary: 'Epsilon'  Key being added: 'Epsilon'
        names.Add(false, true); 

        WriteLine("foreach DictionaryEntry");
        foreach (DictionaryEntry entry in names)
        {
            WriteLine("Key:{0}, Value:{1}", entry.Key, entry.Value);
        }
        WriteLine();
 
        WriteLine("Keys Writer");
        names.Keys.OfType<object>().ToList().ForEach(Writer);
        WriteLine();

        WriteLine("Values Writer");
        names.Values.OfType<object>().ToList().ForEach(Writer);
        WriteLine();

        List<object> listKeys1 = names.Keys.OfType<object>().ToList();
        List<object> listKeys2 = names.Keys.Cast<object>().ToList();
        List<string> listKeys3 = names.Keys.OfType<string>().ToList();
        List<object> listValues1 = names.Values.OfType<object>().ToList();
        List<object> listValues2 = names.Values.Cast<object>().ToList();
        List<int> listValues3 = names.Values.OfType<int>().ToList();        
        string k = "Delta";
        WriteLine("Key:{0}", k);
        var v = names.Keys.OfType<object>().FirstOrDefault(key => Convert.ToString(names[key]) == "Delta");
        WriteLine("Value:{0}", names[k]);
        WriteLine();

        WriteLine("names.Keys.OfType<object>().ToList().ForEach");
        names.Keys.OfType<object>().ToList().ForEach(key => WriteLine("Key:{0}, Value:{1}", key, names[key]));
        WriteLine();
        
        WriteLine("names.Values.OfType<object>().ToList().ForEach");
        names.Values.OfType<object>().ToList().ForEach(value => WriteLine("Key:{0}, Value:{1}", names.Keys.OfType<object>().FirstOrDefault(key => names[key] == value), value));
        WriteLine();

        WriteLine("FindKey");
        names.Values.OfType<object>().ToList().ForEach(value => WriteLine("Key:{0}, Value:{1}", FindKey(value, names), value));
        WriteLine();

        WriteLine("--lambda--");
        names.Keys.OfType<object>().ToList().ForEach(delegate(object key)
        {
            WriteLine("Key:{0}, Value:{1}", key, names[key]);
        }); 
   }

    static void Main()
    {
	Program prgm = new Program();
	prgm.Method();
    }
}

/* 
foreach DictionaryEntry
Key:Gamma, Value:3
Key:Alpha, Value:1
Key:Epsilon, Value:5
Key:Beta, Value:2
Key:False, Value:True
Key:Delta, Value:4

Keys Writer
Value:Gamma
Value:Alpha
Value:Epsilon
Value:Beta
Value:False
Value:Delta

Values Writer
Value:3
Value:1
Value:5
Value:2
Value:True
Value:4

Key:Delta
Value:4

names.Keys.OfType<object>().ToList().ForEach
Key:Gamma, Value:3
Key:Alpha, Value:1
Key:Epsilon, Value:5
Key:Beta, Value:2
Key:False, Value:True
Key:Delta, Value:4

names.Values.OfType<object>().ToList().ForEach
Key:Gamma, Value:3
Key:Alpha, Value:1
Key:Epsilon, Value:5
Key:Beta, Value:2
Key:False, Value:True
Key:Delta, Value:4

FindKey
Key:Gamma, Value:3
Key:Alpha, Value:1
Key:Epsilon, Value:5
Key:Beta, Value:2
Key:False, Value:True
Key:Delta, Value:4

--lambda--
Key:Gamma, Value:3
Key:Alpha, Value:1
Key:Epsilon, Value:5
Key:Beta, Value:2
Key:False, Value:True
Key:Delta, Value:4
*/