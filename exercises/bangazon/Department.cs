using System;
using System.Collections.Generic;

namespace bangazon
{
    public class Department
    {
        private string _name;
        private string _supervisor;
        private int _employee_count;

        public Department(string name, string supervisor, int employees)
        {
            _name = name;
            _supervisor = supervisor;
            _employee_count = employees;
        }

        public string toString()
        {
            return $"{_name} {_supervisor} {_employee_count}";
        }

        public string GetName()
        {
            return _name;
        }
        public string GetSupervisor()
        {
            return _supervisor;
        }
        public int GetEmployeeNum()
        {
            return _employee_count;
        }

    }
    public class Accounting : Department
    {
        private string _location;
        private double _budget;
        private Dictionary<string, string> _policies = new Dictionary<string, string>();
        // private Dictionary<int, Employee> _employees = new Dictionary<string, string>();

        public Accounting(string dept_name, string supervisor, int employees, string location, double budget) : base(dept_name, supervisor, employees)
        {
            _location = location;
            _budget = budget;
        }
        
        public void AddPolicy(string title, string text)
        {
            _policies.Add(title, text);

            foreach(KeyValuePair<string, string> policy in _policies)
            {
                Console.WriteLine($"{policy.Value}");
            }
        }

        public string toString()
        {
            return $"{GetName()} {GetSupervisor()} {GetEmployeeNum()} {_location} {_budget}";
        }
    }

    public class HumanResources : Department
    {
        private string _location;
        private double _budget;
        private Dictionary<string, string> _policies = new Dictionary<string, string>();
        // private Dictionary<int, Employee> _employees = new Dictionary<string, string>();
        
        public HumanResources(string dept_name, string supervisor, int employees, string location, double budget) : base(dept_name, supervisor, employees)
        {
            _location = location;
            _budget = budget;
        }
        
        public void AddPolicy(string title, string text)
        {
            _policies.Add(title, text);

            foreach(KeyValuePair<string, string> policy in _policies)
            {
                Console.WriteLine($"{policy.Value}");
            }
        }

        public string toString()
        {
            return $"{GetName()} {GetSupervisor()} {GetEmployeeNum()} {_location} {_budget}";
        }        
    }

    public class IT : Department
    {
        private string _location;
        private double _budget;
        private Dictionary<string, string> _policies = new Dictionary<string, string>();
        // private Dictionary<int, Employee> _employees = new Dictionary<string, string>();
        
        public IT(string dept_name, string supervisor, int employees, string location, double budget) : base(dept_name, supervisor, employees)
        {
            _location = location;
            _budget = budget;
        }
        
        public void AddPolicy(string title, string text)
        {
            _policies.Add(title, text);

            foreach(KeyValuePair<string, string> policy in _policies)
            {
                Console.WriteLine($"{policy.Value}");
            }
        }

        public string toString()
        {
            return $"{GetName()} {GetSupervisor()} {GetEmployeeNum()} {_location} {_budget}";
        }
    }

    public class Marketing : Department
    {
        private string _location;
        private double _budget;
        private Dictionary<string, string> _policies = new Dictionary<string, string>();
        // private Dictionary<int, Employee> _employees = new Dictionary<string, string>();
        
        public Marketing(string dept_name, string supervisor, int employees, string location, double budget) : base(dept_name, supervisor, employees)
        {
            _location = location;
            _budget = budget;
        }
        
        public void AddPolicy(string title, string text)
        {
            _policies.Add(title, text);

            foreach(KeyValuePair<string, string> policy in _policies)
            {
                Console.WriteLine($"{policy.Value}");
            }
        }

        public string toString()
        {
            return $"{GetName()} {GetSupervisor()} {GetEmployeeNum()} {_location} {_budget}";
        }
    }

    public class Sales : Department
    {
        private string _location;
        private double _budget;
        private Dictionary<string, string> _policies = new Dictionary<string, string>();
        // private Dictionary<int, Employee> _employees = new Dictionary<string, string>();
        
        public Sales(string dept_name, string supervisor, int employees, string location, double budget) : base(dept_name, supervisor, employees)
        {
            _location = location;
            _budget = budget;
        }
        
        public void AddPolicy(string title, string text)
        {
            _policies.Add(title, text);

            foreach(KeyValuePair<string, string> policy in _policies)
            {
                Console.WriteLine($"{policy.Value}");
            }
        }

        public string toString()
        {
            return $"{GetName()} {GetSupervisor()} {GetEmployeeNum()} {_location} {_budget}";
        }
    }
}