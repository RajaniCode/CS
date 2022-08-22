using System;
using System.Collections;
using System.Collections.Generic;

class Student
{
    public string firstName;
    public string lastName;

    public Student(string firstName, string lastName)
    {
        this.firstName = firstName;
        this.lastName = lastName;
    }
}

class Enrollment<T> : IEnumerable<T>
{
    private List<Student> allStudents = new List<Student>();

    public void Enroll(Student s)
    {
        allStudents.Add(s);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return ((IEnumerable<T>)allStudents).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable<Student>)allStudents).GetEnumerator();
    }
}

class Program
{
    static void Main()
    {
        Enrollment<Student> enumerableStudent = new  Enrollment<Student>();
        enumerableStudent.Enroll(new Student("Bill", "Gates"));
        enumerableStudent.Enroll(new Student("Steve", "Jobs"));
        enumerableStudent.Enroll(new Student("Larry", "Page"));    

        IEnumerator<Student> enumeratorStudent = enumerableStudent.GetEnumerator();
        while (enumeratorStudent.MoveNext())
        {
            Console.WriteLine("{0} {1}", enumeratorStudent.Current.firstName, enumeratorStudent.Current.lastName);
        }

        /*
        foreach (Student stdnt in enumerableStudent)
        {
            Console.WriteLine("{0} {1}", stdnt.firstName,stdnt.lastName);
        }
        */
    }
}