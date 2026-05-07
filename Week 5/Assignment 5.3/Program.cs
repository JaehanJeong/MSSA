//1.You have a long flowerbed in which some of the plots are planted, and some are not.
//However, flowers cannot be planted in adjacent plots.

//Given an integer array flowerbed containing 0's and 1's,
//where 0 means empty and 1 means not empty, and an integer n,
//return true if n new flowers can be planted in the flowerbed
//without violating the no-adjacent-flowers rule and false otherwise.

//Question#1

//Initial thought
//1. Iterate thru flowerbed array
//2. Foreach spot, check left & right neighbor.
//3. If both are 0s (empty), then increment 1.
//4. Seems workable...

//Second thought
//1. Start with first and end 2's to see if we can plant on each end.
//2. Afterwards, look for 3 consecutive 0's since that's the only places we can plant (in the middle)
int flowerBedSize = 0;
while (true)
{
    //How big is their flowerBedSize?
    //Let the user tell us the array size
    Console.WriteLine("Please input the number of spaces in your flower bed.");
    if (int.TryParse(Console.ReadLine(), out flowerBedSize) && flowerBedSize > 0)
        break;
    Console.WriteLine("Please enter a positive whole number.");
}
//Create the flower bed array
int[] flowerBed = new int[flowerBedSize];


//Populate the flowerBed with 1/0s to see where they have flowers.
int index = 0;
int plants = 0;

while (index <= flowerBed.Length-1)
{
    Console.WriteLine($"Does the {index+1} slot have a flower? Enter 0 if empty, and 1 if it has flower.");
    if (int.TryParse(Console.ReadLine(),out int flower))
    {
        //If user says 0, then set the index as 0. 
        if (flower == 0)
        {
            flowerBed[index] = 0;
        }
        //If user says 1, then set the index as 1.
        if (flower == 1)
        {
            flowerBed[index] = 1;
        }
        index++;
    }

}
if(flowerBedSize <= 3)
{
    if (flowerBed[0] == 0 && flowerBed[1] == 0 && flowerBed[2] == 0)
    {
        flowerBed[0] = 1;
        flowerBed[2] = 1;
        plants += 2;
    }
    if (flowerBed[1] == 1)
        Console.WriteLine("You can't print more trees in this small flowerbed.");
}



//Now we have the flower bed in front of us.
//What do we do now?

//Check 2 indicies at each end, to see if either end could use a plant.
//If first two are missing a flower, plant one at the start.
if (flowerBed[0] == 0 && flowerBed[1] == 0)
{
    flowerBed[0] = 1;
    plants++;
}


//If last two are missing a flower, plant one at the end.
if (flowerBed[flowerBed.Length - 1] == 0 && flowerBed[flowerBed.Length - 2] == 0)
{
    flowerBed[flowerBed.Length - 1] = 1;
    plants++;
}


//Now we are ready to look through the whole bed to look for triple 0s so we can put 1 flower in the middle.

int wantToPlant = 0;
for (int i = 2; i <= flowerBedSize - 3; i ++)
{
    if (flowerBed[i] == 0 && flowerBed[i - 1] == 0 && flowerBed[i + 1] == 0)
    {
        flowerBed[i] = 1;
        plants++;
        i++;
    }
    else i++;
}


while (true)
{
    //How many flowers you wana plant?
    //Let the user tell us the plants number.
    Console.WriteLine("Please enter the number of flowers you'd like to plant. ");
    if (int.TryParse(Console.ReadLine(), out wantToPlant) && wantToPlant >= 0)
        break;
    Console.WriteLine("Please enter a valid number.");
}

if (wantToPlant > plants) Console.WriteLine("False");
else Console.WriteLine("True.");