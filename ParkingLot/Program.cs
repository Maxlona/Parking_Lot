using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ParkingLot
{

    internal class Program
    {
        static void Main(string[] args)
        {
           
            /// this lot can take has 10 spaces
            ParkingLot lot = new ParkingLot(5);

            ///////////////// add remove a car
            var vehicle = new Vehicle()
            {
                PlateNumber = "RDA1SAZ",
                VehicleType = VehicleSpecs.RV,
                ParkedAt = DateTime.UtcNow,
            };

            if (lot.CanPark(vehicle))
            {
                var carAdded = lot.AddVehicle(vehicle);
                if (carAdded)
                    Console.WriteLine($"Added new vehicle {vehicle.PlateNumber}");
            }
            else
            {
                Console.WriteLine("Parking lot is full, can't open the gate");
            }

            var removed = lot.RemoveVehicle(vehicle);
            if (removed)
            {
                Console.WriteLine($"Removed vehicle {vehicle.PlateNumber}");
            }
            else
            {
                Console.WriteLine("Such a vehicle was not found!");
            }

            Console.ReadLine();
        }
    }
}
