// Pre-CS 2 
// Non-Generic IEnumerable and IEnumerator interfaces
// Generic versions of IEnumerable and IEnumerator interfaces (>= CS 2)  prevent the additional cost of boxing/unboxing

using System;
using System.Collections;

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

class EnumerableType : IEnumerable
{
    private Person[] persons; 
 
    public EnumerableType(Person[] persons)
    {
        this.persons = new Person[persons.Length];

        for (int i = 0; i < persons.Length; i++)
        {
            this.persons[i] = persons[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
       return (IEnumerator) GetEnumerator();
    }

    public EnumeratorType GetEnumerator()
    {
        return new EnumeratorType(persons);
    }
}

class EnumeratorType : IEnumerator
{
    public Person[] persons;

    // Enumerators are positioned before the first element until the first MoveNext() call
    int position = -1;

    public EnumeratorType(Person[] persons)
    {
        this.persons = persons;
    }

    public bool MoveNext()
    {
        position++;
        return (position < persons.Length);
    }

    public void Reset()
    {
        position = -1;
    }

    object IEnumerator.Current
    {
        get
        {
            return Current;
        }
    }

    public Person Current
    {
        get
        {
            try
            {
                return persons[position];
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Non-Generic IEnumerable and IEnumerator interfaces");
        Person[] persons = new Person[3] { new Person("Bill", "Gates"), new Person("Steve", "Jobs"), new Person("Larry", "Page") };

        EnumerableType enumerable = new EnumerableType(persons);
        EnumeratorType enumerator = enumerable.GetEnumerator();
        Console.WriteLine("EnumeratorType");
        while (enumerator.MoveNext())
        {
            Console.WriteLine("{0} {1}", enumerator.Current.firstName, enumerator.Current.lastName);
        }        
       
        /*       
        // The compiler translates the foreach block to a while loop like the earlier example
        // Under the hood, it’ll use the IEnumerator object returned from GetEnumerator method
        // While you can use the foreach block on any types that implements IEnumerable, IEnumerable is not designed for the foreach block
        Console.WriteLine("EnumerableType");
        foreach (Person p in enumerable)
        {
            Console.WriteLine("{0} {1}", p.firstName, p.lastName);
        }
        */        
    }
}

/*
// IEnumerable and IEnumerator interfaces are implementations of the iterator pattern
// IEnumerable interface
// Exposes an enumerator, which supports a simple iteration over a non-generic collection
// The GetEnumerator method here returns an IEnumerator object, which can be used to iterate (or enumerate) the given object
public interface IEnumerable
{
    IEnumerator GetEnumerator();
}

// When you implement IEnumerable, you must also implement IEnumerator
// IEnumerator interface
// Supports a simple iteration over a non-generic collection
// With this, the client code can use the MoveNext() method to iterate the given object and use the Current property to access one element at a time
public interface IEnumerator
{
    bool MoveNext();
    object Current { get; }
    void Reset();
}
*/