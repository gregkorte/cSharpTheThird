using System;
using System.Collections.Generic;

namespace classes
{
    class Program
    {
        static void Main(string[] args)
        {
            Company myco = new Company("MyCo", DateTime.Now);

            Employee ted = new Employee("Ted", DateTime.Now, "Drone");
            Employee sally = new Employee("Sally", DateTime.Now, "Queen");
            Employee bill = new Employee("Bill", DateTime.Now, "Drone");
            Employee phil = new Employee("Phil", DateTime.Now, "Soldier");

            List<Employee> myCoEmployees = new List<Employee>();
            
            myco.Employees = myCoEmployees;
            myco.addEmployee(ted, myCoEmployees);
            myco.addEmployee(phil, myCoEmployees);
            myco.addEmployee(bill, myCoEmployees);
            myco.addEmployee(sally, myCoEmployees);

            myco.deleteEmployee(ted, myCoEmployees);
            
            myco.listEmployees();
        }

        // Create a class that contains information about employees of a company and define methods to get/set employee name, job title, and start date.
        public class Employee
        {
            public string Name { get; set; }
            public DateTime CreatedOn { get; set; }
            public string JobTitle { get; set; }

            public Employee(string name, DateTime date, string jobTitle) 
            {
                this.Name = name;
                this.CreatedOn = date;
                this.JobTitle = jobTitle;
            }
        }

        public class Company
        {
            /*
                Some readonly properties
            */
            public string Name { get; }
            public DateTime CreatedOn { get; }

            // Create a property for holding a list of current employees
            public List<Employee> Employees { get; set; }

            // Create a method that allows external code to add an employee
            public void addEmployee(Employee emp, List<Employee> com)
            {
                com.Add(emp);
            }
           
            // Create a method that allows external code to remove an employee
            public void deleteEmployee(Employee emp, List<Employee> com)
            {
                com.Remove(emp);
            }

            public void listEmployees()
            {
                foreach(Employee emp in Employees){
                Console.WriteLine($"{emp.Name} started on {emp.CreatedOn} as a {emp.JobTitle}");
                }
            }
            /*
                Create a constructor method that accepts two arguments:
                    1. The name of the company
                    2. The date it was created

                The constructor will set the value of the public properties
            */
            public Company(string name, DateTime date)
            {
                this.Name = name;
                this.CreatedOn = date;
            }
        }
    }
}
