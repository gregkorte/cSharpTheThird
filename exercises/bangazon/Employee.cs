using System;
using System.Collections.Generic;

namespace bangazon
{
    public interface IFullTime
    {
        double Salary { get; set; }
    }

    public interface IPartTime
    {
        double HourlyRate { get; set; }
    }

    public class Employee
    {
        private string _first_name;
        private string _last_name;
        public Employee(string first, string last)
        {
            this._first_name = first;
            this._last_name = last;
        }

        public string getFullName()
        {
            return $"{_first_name} {_last_name}";
        }

        public string eat()
        {
            List<string> restaurants = new List<string>(){"Here", "There", "Yon", "Everywhere"};
            Random random = new Random();
            int r = random.Next(restaurants.Count);
            Console.WriteLine($"{getFullName()} is eating {restaurants[r]} today.");
            return $"{restaurants[r]}";
        }

        public string eat(string food)
        {
            return $"{getFullName()} ate {food} today.";
        }

        public List<string> eat(List<Employee> companions)
        {
            List<string> restaurants = new List<string>(){"Here", "There", "Yon", "Everywhere"};
            List<string> coworkers = new List<string>();
            Random random = new Random();
            int r = random.Next(restaurants.Count);
            Console.WriteLine($"{getFullName()} is eating {restaurants[r]} today.");
            foreach(Employee c in companions){
                coworkers.Add(c._first_name);
            }
            return coworkers;
        }

        public void eat(string food, List<Employee> companions)
        {
            List<string> restaurants = new List<string>(){"Here", "There", "Yon", "Everywhere"};
            List<string> coworkers = new List<string>();
            Random random = new Random();
            int r = random.Next(restaurants.Count);
            foreach(Employee c in companions){
                coworkers.Add(c._first_name);
            }
            Console.WriteLine($"{getFullName()} is eating {food} today at {restaurants[r]} with {String.Join(", ", coworkers)}.");
        }
        
    }

    public class HumanResourcesEmployee : IFullTime
    {
        private double _salary;

        public double Salary
        {
            get { return _salary; }
            set
            {
                if(value >= 10 && value <= 35)
                {
                    _salary = value;
                } else {
                    throw new ArgumentOutOfRangeException("Cannot set salary to value specified");
                }
            }
        }
    }

}