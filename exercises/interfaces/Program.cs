using System;
using System.Linq;
using System.Collections.Generic;

namespace interfaces
{

    public interface IVehicle
    {
        string Name { get; set; }
        int PassengerCapacity { get; set; }
        string TransmissionType { get; set; }
        double EngineVolume { get; set; }
        void Start();
        void Stop();
    }

    public interface IAirBased : IVehicle
    {
        int Doors { get; set; }
        bool Winged { get; set; }
        double MaxAirSpeed { get; set; }
        void Fly();
    }

    public interface ILandBased : IVehicle
    {
        int Wheels { get; set; }
        int Doors { get; set; }
        double MaxLandSpeed { get; set; }
        void Drive();
    }

    public interface IWaterBased : IVehicle
    {
        double MaxWaterSpeed { get; set; }
        void Drive();
    }

    public class WaterCraft : IWaterBased
    {
        public string Name { get; set; }
        public int PassengerCapacity { get; set; }
        public string TransmissionType { get; set; }
        public double EngineVolume { get; set; }
        public double MaxWaterSpeed { get; set; }

        public void Drive()
        {
            Console.WriteLine($"The {Name} zips through the waves with the greatest of ease.");
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public WaterCraft(string name, int speed, int passengers)
        {
            this.Name = name;
            this.MaxWaterSpeed = speed;
            this.PassengerCapacity = passengers;
        }
    }

    public class LandCraft : ILandBased
    {
        public string Name { get; set; }
        public int Wheels { get; set; }
        public int Doors { get; set; }
        public int PassengerCapacity { get; set; }
        public string TransmissionType { get; set; }
        public double EngineVolume { get; set; }
        public double MaxLandSpeed { get; set; }

        public void Drive()
        {
            if(this.MaxLandSpeed < 100)
            {
                Console.WriteLine($"The {Name} putzes down the highway.");
                
            }
            else if(this.MaxLandSpeed >= 100 && this.MaxLandSpeed <= 200)
            {
                Console.WriteLine($"The {Name} drifts down the highway.");
            }
            else
                Console.WriteLine($"The {Name} screams down the highway."); 
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public LandCraft(string name, int speed, int doors)
        {
            this.Name = name;
            this.MaxLandSpeed = speed;
            this.Doors = doors;
        }
    }

    public class AirCraft : IAirBased
    {
        public string Name { get; set; }
        public int Wheels { get; set; }
        public int Doors { get; set; }
        public int PassengerCapacity { get; set; }
        public bool Winged { get; set; }
        public string TransmissionType { get; set; }
        public double EngineVolume { get; set; }
        public double MaxAirSpeed { get; set; }

        public void Fly()
        {
            Console.WriteLine($"The {Name} effortlessly glides through the clouds like a gleaming god of the Sun.");
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public AirCraft(string name, int speed, bool wing)
        {
            this.Name = name;
            this.MaxAirSpeed = speed;
            this.Winged = wing;
        }
    }


    public class Program
    {

        public static void Main() {

            // Build a collection of all vehicles that fly
            List<AirCraft> flyers = new List<AirCraft>();

            AirCraft cessna = new AirCraft("cessna", 280, true);
            AirCraft hindenburg = new AirCraft("hindenberg", 130, false);
            AirCraft sr71 = new AirCraft("sr71", 2000, true);
            flyers.Add(cessna);
            flyers.Add(hindenburg);
            flyers.Add(sr71);

            // With a single `foreach`, have each vehicle Fly()
            foreach(AirCraft f in flyers){
                f.Fly();
            }

            // Build a collection of all vehicles that operate on roads
            List<LandCraft> land = new List<LandCraft>();

            LandCraft bicycle = new LandCraft("bicycle", 5, 0);
            LandCraft civic = new LandCraft("civic", 140, 4);
            LandCraft formula1 = new LandCraft("formula1", 250, 0);
            land.Add(bicycle);
            land.Add(civic);
            land.Add(formula1);

            // With a single `foreach`, have each road vehicle Drive()
            foreach(LandCraft l in land){
                l.Drive();
            }

            // Build a collection of all vehicles that operate on water
            List<WaterCraft> water = new List<WaterCraft>();
            WaterCraft raft = new WaterCraft("raft", 2, 2);
            WaterCraft yacht = new WaterCraft("yacht", 25, 50);
            WaterCraft jetski = new WaterCraft("jetski", 40, 1);
            water.Add(raft);
            water.Add(yacht);
            water.Add(jetski);
            
            // With a single `foreach`, have each water vehicle Drive()
            foreach(WaterCraft w in water)
            {
                w.Drive();
            }
        }

    }
}
