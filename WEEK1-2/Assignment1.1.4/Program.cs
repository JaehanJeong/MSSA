// Create a structure called point
using Assignment1._1._4.Model;
using Assignment1._1._4.Models;

//
//void compareXCoordinates(Point p1, Point p2)
//{
//    if (p2.xCoordinate > p1.xCoordinate)
//    {
//        Console.WriteLine("Point 2 is located on the right side of point 1.");
//    }
//    else if (p2.xCoordinate < p1.xCoordinate)
//    {
//        Console.WriteLine("Point 1 is located on the right side of point 1.");
//    }
//    else if (p2.xCoordinate == p1.xCoordinate)
//    {
//        Console.WriteLine("They are on the same x coordinate :)");
//    }
//}


Console.WriteLine("You will enter the x and y coordinates for first point, then same thing for point 2. We will use those to see which ever is more positive, located higher, and the distance between them.");

Point firstPoint = new Point();

//firstPoint.xCoordinate = 6; // Now making the user input the x coordinate
Console.WriteLine("Please enter the x coordinate of your first point.");
firstPoint.xCoordinate = Convert.ToDouble(Console.ReadLine());
//firstPoint.yCoordinate = 7; // Now making the user input the y coordinate
Console.WriteLine("Please enter the y coordinate of your first point.");
firstPoint.yCoordinate = Convert.ToDouble(Console.ReadLine());

Point secondPoint = new Point();
// secondPoint.xCoordinate = 8; Now making the user input the x coordinate for point 2.
Console.WriteLine("Please enter the x coordinate of your second point.");
secondPoint.xCoordinate = Convert.ToDouble(Console.ReadLine());
// secondPoint.yCoordinate = 9; Now making the user input the y coordinate for point 2.
Console.WriteLine("Please enter the y coordinate of your second point.");
secondPoint.yCoordinate = Convert.ToDouble(Console.ReadLine());

firstPoint.compareXCoordinates(firstPoint, secondPoint);
secondPoint.compareYCoordinates(firstPoint, secondPoint);
firstPoint.calculateDistance(firstPoint, secondPoint);


//Write a class: “Student” with private data members:
//StudentId (int), StudentFname (string), StudentLname (string), StudentGrade (char) and public properties for each data member.
//Instantiate the class and assign data to properties. Display the data back on console.

Student student = new Student();

student.StudentId = 187;
student.StudentFirstName = "Jaehan";
student.StudentLastName = "Jeong";
student.StudentGrade = 'A';

Console.WriteLine("\n===========Student Profile==============");
Console.WriteLine($"Student ID = {student.StudentId}");
Console.WriteLine($"Student First Name = {student.StudentFirstName}");
Console.WriteLine($"Student Last Name = {student.StudentLastName}");
Console.WriteLine($"Student Grade = {student.StudentGrade}");
Console.WriteLine("========================================");





// 2 more methods
// second one after this compare 2 points and which one is above the other
// find the distance between two points.

