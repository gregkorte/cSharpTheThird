using System;
using System.Collections.Generic;

namespace family_dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, string>> myFamily = new Dictionary<string, Dictionary<string, string>>();

            myFamily.Add("wife", new Dictionary<string, string>(){ 
                {"name", "Melissa"},
                {"age", "45"}
            });
            myFamily.Add("son", new Dictionary<string, string>(){ 
                {"name", "Zach"},
                {"age", "26"}
            });
            myFamily.Add("father", new Dictionary<string, string>(){ 
                {"name", "Don"},
                {"age", "75"}
            });
            myFamily.Add("mother", new Dictionary<string, string>(){ 
                {"name", "Judy"},
                {"age", "75"}
            });
            myFamily.Add("brother", new Dictionary<string, string>(){ 
                {"name", "Mike"},
                {"age", "41"}
            });

            /*
            Next, iterate over each item in myFamily and produce the following output.

            Krista is my sister and is 42 years old
            */
            foreach(KeyValuePair<string, Dictionary<string, string>> relative in myFamily){
                string name = "";
                string age = "";
                foreach(KeyValuePair<string, string> rProp in relative.Value){
                    if(rProp.Key == "name"){
                        name = rProp.Value;
                    } else {
                        age = rProp.Value;
                    }
                }
                Console.WriteLine($"{name} is my {relative.Key} and is {age} years old.");
            }
        }
    }
}
