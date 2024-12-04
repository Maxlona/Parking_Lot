# Parking Lot
 Logic to add, remove vehicles from Parking Lot

**Assumptions:**
- The Parking Lot must have a maximum number of spaces allowed!
- The Parking Lot can take certain types of vehicles, e.g., Regular, Motorcycle, Truck, Van  or RV
- Each Vehicle has a different allocation size, for instance, an RV equals 3 regular spots, 
- These are the sizing chart:
  Motorcycle  	// 1 spot
  Regular,    	// 1 spot
  Truck,      	// 2 spot
  Van,        	// 2 spot
  RV			        // 3 spots

**Requirements:**
- Parking Lot (PL) can not park vehicles over the max allowed limit on initialization.
- PL available spaces must gain back the available spot when a car leaves.
- PL can not remove a car, unless the license plate matches.
- PL uses UTC time to track when a car is parked.
- PL Much check/verify if a car can park (given the spaces available) before checking in a new car.
- Must add unit testing to verify functionality
