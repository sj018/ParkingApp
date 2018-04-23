# ParkingApp
This is a simple parking application which has basic CRUD functionality.

 Models:
   Car: Have car details like id, carNumber, carOwner, carOwnersContact
   Parking: Have parking details like id, list of Cars parked, Car parked at a particular id, parking startime and endtime

 Controller:
  ParkingController: Have the implementation for
    - adding details of car parked
    - updating details of car parked
    - Getting details of car parked as per the id
    - Removing car parked from parking spot as per its id
