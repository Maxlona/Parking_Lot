namespace ParkingLot
{
    public interface IParkingLot
    {
        bool AddVehicle(Vehicle vehicle);
        int AvailableSpots();
        bool CanPark(Vehicle vehicle);
        bool IsFull();
        bool RemoveVehicle(Vehicle vehicle);
    }
}