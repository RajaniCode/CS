using System;
using System.Collections;
using System.Collections.Generic;

// Business object
class Person
{
    public string firstName;
    public string lastName;

    public Person(string firstName, string lastName)
    {
        this.firstName = firstName;
        this.lastName = lastName;
    }
}

class EnumerableType<T> : IEnumerable<T>
{
    T[] items = null;
    int index = 0;

    public EnumerableType()
    {
        // For the sake of simplicity lets keep them as arrays
        // ideally it should be link list
        items = new T[100];
    }

    public void Add(T item)
    {
        // Let us only worry about adding the item 
        items[index] = item;
        index++;
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (T t in items)
        {
            // Lets check for end of list (since it is array)
            if (t == null) // This wont work if T is not a nullable type
            {
                break;
            }

            // Return the current element and then on next function call 
            // Resume from next element rather than starting all over again
            yield return t;
        }
    }

    // System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    IEnumerator IEnumerable.GetEnumerator()
    {
        // Lets call the generic version here
        return this.GetEnumerator();
    }
}

class Program
{
    static void Main()
    {
        EnumerableType<string> enumerable = new  EnumerableType<string>();
        enumerable.Add("Alpha");
        enumerable.Add("Beta");
        enumerable.Add("Gamma");
        enumerable.Add("Delta");
        enumerable.Add("Epsilon");

        IEnumerator<string> enumerator = enumerable.GetEnumerator();
        while (enumerator.MoveNext())
        {
            Console.WriteLine(enumerator.Current);
        }  

        /*
        foreach (string s in enumerable)
        {
            Console.WriteLine(s);
        }
        */

        // Person[] persons = new Person[3] { new Person("Bill", "Gates"), new Person("Steve", "Jobs"), new Person("Larry", "Page") };
        EnumerableType<Person> enumerablePerson = new  EnumerableType<Person>();
        enumerablePerson.Add(new Person("Bill", "Gates"));
        enumerablePerson.Add(new Person("Steve", "Jobs"));
        enumerablePerson.Add(new Person("Larry", "Page"));    

        IEnumerator<Person> enumeratorPerson = enumerablePerson.GetEnumerator();
        while (enumeratorPerson.MoveNext())
        {
            Console.WriteLine("{0} {1}", enumeratorPerson.Current.firstName, enumeratorPerson.Current.lastName);
        }    
    }
}
