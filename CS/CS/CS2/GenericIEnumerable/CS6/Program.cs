using System;
using System.Collections;
using System.Collections.Generic;

// public // Inconsistent accessibility: parameter type 'Student' is less accessible than method 'StudentExtensions.Add(Enrollment, Student)'
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

// public parameter type 'Enrollment<Student>' is less accessible than method 'StudentExtensions.Add(Enrollment<Student>, Student)'
class Enrollment<T> : IEnumerable<T>
{
    private List<Student> allStudents = new List<Student>();
    
    // The Enroll method adds a student
    // However it doesn't follow the Add pattern
    // In previous versions of C#, you could not use collection initializers with an Enrollment object
    /*
    public void Add(Student s)
    {
        allStudents.Add(s);
    }
    */
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

// public static class StudentExtensions // Inconsistent accessibility: parameter type 'Enrollment<Student>' is less accessible than method 'StudentExtensions.Add(Enrollment<Student>, Student)'
static class StudentExtensions
{
    public static void Add(this Enrollment<Student> e, Student s) => e.Enroll(s);
}

class Program
{
    static void Main()
    {
        /*
        Enrollment<Student> enumerableStudent = new  Enrollment<Student>();
        enumerableStudent.Enroll(new Student("Bill", "Gates"));
        enumerableStudent.Enroll(new Student("Steve", "Jobs"));
        enumerableStudent.Enroll(new Student("Larry", "Page"));    

        IEnumerator<Student> enumeratorStudent = enumerableStudent.GetEnumerator();
        while (enumeratorStudent.MoveNext())
        {
            Console.WriteLine("{0} {1}", enumeratorStudent.Current.firstName, enumeratorStudent.Current.lastName);
        }


        foreach (Student stdnt in enumerableStudent)
        {
            Console.WriteLine("{0} {1}", stdnt.firstName,stdnt.lastName);
        }
        */

        var classList = new Enrollment<Student>()
        {
            new Student("Lessie", "Crosby"),
            new Student("Vicki", "Petty"),
            new Student("Ofelia", "Hobbs"),
            new Student("Leah", "Kinney"),
            new Student("Alton", "Stoker"),
            new Student("Luella", "Ferrell"),
            new Student("Marcy", "Riggs"),
            new Student("Ida", "Bean"),
            new Student("Ollie", "Cottle"),
            new Student("Tommy", "Broadnax"),
            new Student("Jody", "Yates"),
            new Student("Marguerite", "Dawson"),
            new Student("Francisca", "Barnett"),
            new Student("Arlene", "Velasquez"),
            new Student("Jodi", "Green"),
            new Student("Fran", "Mosley"),
            new Student("Taylor", "Nesmith"),
            new Student("Ernesto", "Greathouse"),
            new Student("Margret", "Albert"),
            new Student("Pansy", "House"),
            new Student("Sharon", "Byrd"),
            new Student("Keith", "Roldan"),
            new Student("Martha", "Miranda"),
            new Student("Kari", "Campos"),
            new Student("Muriel", "Middleton"),
            new Student("Georgette", "Jarvis"),
            new Student("Pam", "Boyle"),
            new Student("Deena", "Travis"),
            new Student("Cary", "Totten"),
            new Student("Althea", "Goodwin")
        };

        IEnumerator<Student> enumeratorStudentclassList = classList.GetEnumerator();
        while (enumeratorStudentclassList.MoveNext())
        {
            Console.WriteLine("{0} {1}", enumeratorStudentclassList.Current.firstName, enumeratorStudentclassList.Current.lastName);
        }

        /*
        foreach (Student stdnt in classList)
        {
            Console.WriteLine("{0} {1}", stdnt.firstName,stdnt.lastName);
        }
        */
    }
}