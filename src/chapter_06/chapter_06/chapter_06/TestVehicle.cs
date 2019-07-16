using System;

namespace chapter_06
{
    class TestVehicle<T> where T : Vehicle, new()
    {
        T VehicleType { get; set; }

        public TestVehicle(T vehicleType)
        {
            VehicleType = vehicleType;
        }

        public void GetVehicleType()
        {
            VehicleType.PrintMessage();
        }
    }
}
