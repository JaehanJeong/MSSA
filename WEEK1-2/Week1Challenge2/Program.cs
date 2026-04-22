//Challenge Assignment
//Design 3 classes for a program to do a task of your choice.
//Each class must have at least three properties.
//Then create a new console app, create a "Models" folder and implement the Classes in your folder.



using Week1Challenge2.Models;


Console.WriteLine("Welcome to MSSA clinic!. Are you a walk-in or did you have an appointment? Enter 1 for walk-in and 2 for appointment");
int walkInOrNot = Convert.ToInt32(Console.ReadLine());
int availableDoc = 5;
switch (walkInOrNot)
{
    //case 1: function to grab a docta if available
    //case 2: function to schedule an appointment
}

/*
void grabDocta()
{
    if (availableDoc > 0)
    {
        Console.WriteLine()
    }
}
*/

// Use at least one of the classes you designed yday to instantiate multiple objects
// and assign values to some properties
Patient patient1 = new Patient();
patient1.PatientName = "UncaleSam";
patient1.DateOfBirth = 20000704;

Patient patient2 = new Patient();
patient2.PatientName = "Joe";
patient2.DateOfBirth = 19600409;
