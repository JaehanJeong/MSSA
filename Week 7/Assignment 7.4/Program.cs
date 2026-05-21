using Assignment_7._4;

ParkingSystem parking = new(1,1,0);

bool try1 = parking.AddCar(CarType.Large);
Console.WriteLine(try1.ToString());
bool try2 = parking.AddCar(CarType.Medium);
Console.WriteLine(try2.ToString());
bool try3 = parking.AddCar(CarType.Small);
Console.WriteLine(try3.ToString());
bool try4 = parking.AddCar(CarType.Large);
Console.WriteLine(try4.ToString());