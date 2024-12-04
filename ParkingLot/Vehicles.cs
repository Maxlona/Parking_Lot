using System;

namespace ParkingLot
{
    public class Vehicle
    {
        private DateTime parkedAt;
        public string PlateNumber { get; set; }
        public VehicleSpecs VehicleType { get; set; }
        public DateTime ParkedAt
        {
            get { return parkedAt; }
            set
            {
                /// accounting for network latency by allowing a small buffer like 3 seconds
                if (value < DateTime.UtcNow.AddSeconds(-3))
                {
                    throw new ArgumentException("ParkedAt cannot be set to a past date.");
                }
                parkedAt = value;
            }
        }
    }

    public enum VehicleSpecs
    {
        Motorcycle = 1, // 1 spot
        Regular = 1,    // 1 spot
        Truck = 2,      // 2 spot
        Van = 2,        // 2 spot
        RV = 3          // 3 spots
    }
}
