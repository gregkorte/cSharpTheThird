using System;

namespace classes
{
    class Program
    {
        public static void Main(string[] args)
        {
            // The output variable's type is 'string' -- a built in type
            string output = "Nashville Software School";

            // The author variable's type is a Writer -- a custom type you defined
            Writer author = new Writer();
            author.write(output);

            Automobile generic_auto = new Automobile();
            Console.WriteLine("Automobiles go {0}", generic_auto.Accelerate());

            Car stella = new Car();
            Console.WriteLine("Cars go {0}", stella.Accelerate());
            // UseEmergencyBreak method can use the protected SqueezeBreakPads from the Automobile class.
            Console.WriteLine("Applying the brake: {0}", stella.UseEmergencyBrake());
        }
    }

    public class Writer
    {
        public void write (string message)
        {
            Console.WriteLine(message);
        }
    }

    // Base class
    class Automobile {

        public string Accelerate() {
            this.InjectFuel();
            return "zoom!";
        }

        public string Brake() {
            this.SqueezeBrakePads();
            return "skuuuuur";
        }

        protected string SqueezeBrakePads() {
            return "";
        }

        private string InjectFuel() {
            return "fueling";
        }

    }

    // Derived class
    class Car : Automobile {
        public string UseEmergencyBrake() {
            this.SqueezeBrakePads();
            return "skreeeeech!";
        }
    }

}
