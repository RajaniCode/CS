using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSC2008ClassStructStorage
{
    class Program
    {
        List<Employee> EmployeeDetails = new List<Employee>();

        private List<Employee> GetEmployee()
        {
            List<Employee> Emp = new List<Employee>
            {
                new Employee{Id = 1, Name ="Bill", DateOfBirth = new DateTime(1980,12, 31)},
                new Employee{Id = 2, Name ="Larry", DateOfBirth = new DateTime(2000,12, 31)},
                new Employee{Id = 3, Name ="Steve", DateOfBirth = new DateTime(1990,12, 31)}
            };

            //List<Employee> Emp = new List<Employee>();

            //Emp.Add(new Employee(1, "Bill", new DateTime(1980, 12, 31)));
            //Emp.Add(new Employee(2, "Larry", new DateTime(2000, 12, 31)));
            //Emp.Add(new Employee(3, "Steve", new DateTime(1990, 12, 31)));
            
            return Emp;
        }

        //private void StoreEmployee(ref List<Employee> Employ)
        //{
        //    Employ = GetEmployee();
        //}

        private void StoreEmployee()
        {
            List<Employee> Emp = new List<Employee>
            {
                new Employee{Id = 1, Name ="Bill", DateOfBirth = new DateTime(1980,12, 31)},
                new Employee{Id = 2, Name ="Larry", DateOfBirth = new DateTime(2000,12, 31)},
                new Employee{Id = 3, Name ="Steve", DateOfBirth = new DateTime(1990,12, 31)}
            };

            //List<Employee> Emp = new List<Employee>();
            
            //Emp.Add(new Employee(1, "Bill", new DateTime(1980,12, 31)));
            //Emp.Add(new Employee(2, "Larry", new DateTime(2000,12, 31)));
            //Emp.Add(new Employee(3, "Steve", new DateTime(1990,12, 31)));

            EmployeeDetails = Emp;
        }

        private List<Employee> RetrieveEmployee(int iD)
        {
            List<Employee> Employ = new List<Employee>();

            List<Employee> Emp = EmployeeDetails;

            var Query = from Rows in Emp
                        where Rows.Id == iD
                        select Rows;

            Employ = Query.ToList();

            return Employ;
        }

        static void Main()
        {
            Program Pgm = new Program();

            // Pgm.StoreEmployee(ref Pgm.EmployeeDetails);

            Pgm.StoreEmployee();

            List<Employee> Emp = Pgm.RetrieveEmployee(2);

            var Query = from Rows in Emp
                        select Rows;

            //foreach (var Employ in Query)
            foreach (Employee Employ in Query)
            {
                Console.WriteLine("Id: " + Employ.Id);
                Console.WriteLine("Name: " + Employ.Name);
                Console.WriteLine("Date of birth: " + Employ.DateOfBirth);
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }

    // struct Employee
    class Employee
    {
        //public int Id;
        //public string Name;
        //public DateTime DateOfBirth;

        //public Employee(int Id, string Name, DateTime DateOfBirth)
        //{
        //    this.Id = Id;
        //    this.Name = Name;
        //    this.DateOfBirth = DateOfBirth;
        //}

        public int Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public DateTime DateOfBirth
        {
            get;
            set;
        }
    }
}
