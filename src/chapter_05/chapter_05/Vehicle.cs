using System;
using System.Collections.Generic;
using System.Text;

namespace chapter_05
{
    class Vehicle
    {
        protected string Name { get; set; }
        protected int WheelCount { get; set; }
        protected string VehicleType { get; set; }
        public void ShowDetails()
        {
            Console.WriteLine("Vehicle {0} has {1} wheels, hence it is {2} ", Name, WheelCount, VehicleType);
        }
    }

    class FourWheeler : Vehicle
    {
        public FourWheeler(int wheelCount)
        {
            WheelCount = wheelCount;
            VehicleType = "Four Wheeler";
        }
    }

    class TwoWheeler : Vehicle
    {
        public TwoWheeler(int wheelCount)
        {
            WheelCount = wheelCount;
            VehicleType = "Two Wheeler";
        }
    }

    class Car : FourWheeler
    {
        private string Transmission { get; set; }

        public Car(string name, int wheelCount, string transmission) : base(wheelCount)
        {
            Name = name;
            Transmission = transmission;
        }

        public void GetTransmission()
        {
            Console.WriteLine("The transmission of {0} is {1}", Name, Transmission);
        }
    }

    class Bicycle : TwoWheeler
    {
        public Bicycle(string name, int wheelCount) : base(wheelCount)
        {
            Name = name;
        }
    }
}
