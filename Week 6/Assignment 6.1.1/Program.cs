//1.Implement a single linked list with each node representing a house.
//You may add data in it like house number, brief address, type of house ( like Ranch, Colonial) .
//each house (node) will be linked to next .
//Give facility to the user to search a house by its number and then display the details. ( Windows / Console)

using Assignment_6._1._1;

HouseLinkedList houses = new HouseLinkedList();

bool powerOn = true;

while (powerOn)
{
    Console.WriteLine();
    Console.WriteLine("Please select from the following options.");
    Console.WriteLine("1. Add house ");
    Console.WriteLine("2. Remove First House");
    Console.WriteLine("3. Remove Last House");
    Console.WriteLine("4. Search House");
    Console.WriteLine("5. Display Houses");
    Console.WriteLine("6. Exit");


    bool validInput = int.TryParse(Console.ReadLine(), out int userInput);

    if (!validInput)
    {
        Console.WriteLine("Please enter a positive whole number.");
        continue;
    }

    switch (userInput)
    {
        case 1: Console.WriteLine("Enter house number.");
            int houseNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter address");
            string address = Console.ReadLine();

            Console.WriteLine("Enter House type");
            string houseType = Console.ReadLine();

            House newHouse = new House()
            {
                HouseNumber = houseNumber,
                Address = address,
                HouseType = houseType
            };

            houses.AddLast(newHouse);
            Console.WriteLine("Added!");
            break;
        case 2:
            try
            {
                House removedFirst = houses.RemoveFirst();

                Console.WriteLine("Removed!");
                Console.WriteLine(removedFirst.HouseNumber);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            break;
        case 3:
            try
            {
                House removedLast = houses.RemoveLast();

                Console.WriteLine("Removed");
                Console.WriteLine(removedLast.HouseNumber);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            break;
        case 4:
            Console.WriteLine("Enter house number to search: ");
            int searchNumber = int.Parse(Console.ReadLine());

            House? foundHouse = houses.Search(searchNumber);

            if(foundHouse != null)
            {
                Console.WriteLine("House was found.");
                Console.WriteLine($"Address: {foundHouse.Address}");
                Console.WriteLine($"Type: {foundHouse.HouseType}");
            }
            else
            {
                Console.WriteLine("House was not found :( ");
            }
            break;

        case 5:
            houses.Display();
            break;
        case 6:
            powerOn = false;
            Console.WriteLine("Turning off power.");
            break;
        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;

    }

}