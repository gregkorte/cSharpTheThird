using System;
using System.Collections.Generic;

namespace dream_team
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IStudent> clientside = new List<IStudent>();
            List<IStudent> serverside = new List<IStudent>();

            Greg greg = new Greg();
            Deter deter = new Deter();
            Phillipe phillipe = new Phillipe();
            Svetlana svetlana = new Svetlana();
            Anaya anaya = new Anaya();
            Mariana mariana = new Mariana();

            clientside.Add(phillipe);
            clientside.Add(svetlana);
            clientside.Add(anaya);
            serverside.Add(greg);
            serverside.Add(deter);
            serverside.Add(mariana);

            foreach(IStudent s in clientside)
            {
                Console.WriteLine(s.Work());
            }

            foreach(IStudent s in serverside)
            {
                Console.WriteLine(s.Work());
            }
        }

        public interface IStudent 
        {
            string Work();
        };

        public class Greg : IStudent
        {
            public string Specialty { get; set; } = "debugging";
            public static string FirstName { get; set; } = "Greg";
            public static string LastName { get; set; } = "Korte";
            readonly string FullName = $"{FirstName} {LastName}";
            public string Work() 
            {
                return $"{FullName} will be doing all the {Specialty}, like all of it...";
            } 
                
        }
        public class Deter : IStudent
        {
            public string Specialty { get; set; } = "algorithms";
            public static string FirstName { get; set; } = "Deter";
            public static string LastName { get; set; } = "Helmut";
            readonly string FullName = $"{FirstName} {LastName}";
            public string Work()
            {
                return $"{FullName} will be writing all the {Specialty}, cause no one else wants to do math and stuff.";
            }
        }    
        public class Phillipe : IStudent
        {
            public string Specialty { get; set; } = "ui";
            public static string FirstName { get; set; } = "Phillipe";
            public static string LastName { get; set; } = "Forrester";
            readonly string FullName = $"{FirstName} {LastName}";
            public string Work() 
            {
                return $"{FullName} will be designing the {Specialty}. Yay for {FirstName}!";
            }
        }
        public class Svetlana : IStudent
        {
            public string Specialty { get; set; } = "styling";
            public static string FirstName { get; set; } = "Svetlana";
            public static string LastName { get; set; } = "Mikhailov";
            readonly string FullName = $"{FirstName} {LastName}";
            public string Work()
            {
                return $"{FullName} will be creating all the {Specialty}, thank the maker!";
            }
        }
        public class Anaya : IStudent
        {
            public string Specialty { get; set; } = "planning";
            public static string FirstName { get; set; } = "Anaya";
            public static string LastName { get; set; } = "Bhatia";
            readonly string FullName = $"{FirstName} {LastName}";
            public string Work()
            {
                return $"{FullName} will be leading our {Specialty} session. She's good like that.";
            }
        }
        public class Mariana : IStudent
        {
            public string Specialty { get; set; } = "data";
            public static string FirstName { get; set; } = "Mariana";
            public static string LastName { get; set; } = "Lopez";
            readonly string FullName = $"{FirstName} {LastName}";
            public string Work()
            {
                return $"{FullName} will be our {Specialty} architect.";
            }
        }
    }
}
