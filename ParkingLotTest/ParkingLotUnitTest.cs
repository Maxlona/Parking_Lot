using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingLot;
using System;
using System.Linq;
namespace ParkingLotTest
{
    [TestClass]
    public class ParkingLotUnitTest
    {

        ParkingLot.ParkingLot parking;

        [TestMethod]
        public void check_space_should_be_true_if_parking_has_space()
        {
            parking = new ParkingLot.ParkingLot(10);

            Enumerable.Range(1, 6).ToList().ForEach(e =>
            {
                var newVehicle = GeneateNewVehicle(false);
                parking.AddVehicle(newVehicle);
            });

            Assert.IsTrue(parking.CanPark(GeneateNewVehicle(false)));
        }


        [TestMethod]
        public void if_no_space_available_can_not_add_new_car()
        {
            parking = new ParkingLot.ParkingLot(10);
            Enumerable.Range(1, 10).ToList().ForEach(e =>
            {
                var newVehicle = GeneateNewVehicle(false);
                parking.AddVehicle(newVehicle);
            });

            bool CannotAddExtra = parking.AddVehicle(GeneateNewVehicle(false));
            Assert.IsFalse(CannotAddExtra);
        }

        [TestMethod]
        public void check_space_should_be_false_if_parking_full()
        {
            parking = new ParkingLot.ParkingLot(10);
            Enumerable.Range(1, 10).ToList().ForEach(e =>
            {
                var newVehicle = GeneateNewVehicle(true);
                parking.AddVehicle(newVehicle);
            });
            Assert.IsFalse(parking.CanPark(GeneateNewVehicle(false)));
        }


        [TestMethod]
        public void Remove_Vehicle_Should_Pass_if_found()
        {
            parking = new ParkingLot.ParkingLot(10);
            var newVehicle = GeneateNewVehicle(false);
            parking.AddVehicle(newVehicle);
            Assert.IsTrue(parking.RemoveVehicle(newVehicle));
        }


        [TestMethod]
        public void Remove_Vehicle_Should_Fail_if_not_found()
        {
            parking = new ParkingLot.ParkingLot(10);
            var newVehicle = GeneateNewVehicle(false);
            parking.AddVehicle(newVehicle);
            Assert.IsFalse(parking.RemoveVehicle(GeneateNewVehicle(true)));
        }

        [TestMethod]
        public void Invalid_Vehicle_Type_Should_Fail()
        {
            parking = new ParkingLot.ParkingLot(5);
            var newVehicle = GeneateNewVehicle(false);
            newVehicle.VehicleType = 0;
            var exception =  Assert.ThrowsException<Exception>( () =>
            {
                _ = parking.AddVehicle(newVehicle);
            });

            Assert.AreEqual("Invalid vehicle Type", exception.Message);
        }


        private Vehicle GeneateNewVehicle(bool singleSpotOnly)
        {
            Vehicle vehicle = new Vehicle()
            {
                ParkedAt = DateTime.UtcNow,
            };

            vehicle.PlateNumber = Guid.NewGuid().ToString().Replace("-", "")
                .Substring(0, 8).ToUpper();
            /// rndm single type
            Random random = new Random();

            if(singleSpotOnly)
                vehicle.VehicleType = (VehicleSpecs)random.Next(1, 2);
            else
                vehicle.VehicleType = (VehicleSpecs)random.Next(1, 3);

            return vehicle;
        }
    }
}
