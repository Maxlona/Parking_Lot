using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
    public class ParkingLot : IParkingLot
    {
        private readonly List<Vehicle> ParkingSpots = null;
        public ParkingLot(int maxAllowed)
        {
            ParkingSpots = new List<Vehicle>(maxAllowed);
        }

        public int AvailableSpots()
        {
            return (ParkingSpots.Capacity - ParkingSpots.Count);
        }

        public bool IsFull()
        {
            return ParkingSpots.Count == ParkingSpots.Capacity;
        }

        public bool CanPark(Vehicle vehicle)
        {
            if (ParkingSpots.Count == ParkingSpots.Capacity) return false;

            // will it fit?
            int spaceToTake = (int)vehicle.VehicleType;

            if (ParkingSpots.Capacity >= (ParkingSpots.Count + spaceToTake))
            {
                return true;
            }
            return false;
        }

        public bool AddVehicle(Vehicle vehicle)
        {
            if (((int)vehicle.VehicleType == 0) || ((int)vehicle.VehicleType > 3))
                throw new System.Exception("Invalid vehicle Type");

            if (CanPark(vehicle))
            {
                ParkingSpots.Add(vehicle);
                return true;
            }
            return false;
        }

        public bool RemoveVehicle(Vehicle vehicle)
        {
            if (ParkingSpots.Any(e => e.PlateNumber == vehicle.PlateNumber))
            {
                ParkingSpots.Remove(vehicle);
                return true;
            }
            return false;
        }
    }
}
