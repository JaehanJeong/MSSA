//1.Write a program in C# Sharp to find the +ve
//numbers from a list of numbers using where conditions in LINQ Query.
//Input: { 2, -1, 3, -3, 10, -200}
//Expected output: { 2, 3, 10}

using Assignment_10._2;

int[] numbers = { 2, -1, 3, -3, 10, -200 };
var numberresults = from number in numbers
                    where number >= 0
                    select number;
Console.WriteLine($"Numbers greater than 0 is");
foreach(var n in numberresults)
{
    Console.WriteLine( n );
}


//2.Write a program to create a list of employees.
//Consider a hard coded list.
//Display all employees who have salary more than $5000 and age < 30.

List<Employee> employees = new List<Employee>()
{
    new Employee(){ Id = 1, Age = 20, Name = "Joe", Salary = 4999 },
    new Employee(){ Id = 2, Age = 30, Name = "Joe", Salary = 49999 },
    new Employee(){ Id = 3, Age = 40, Name = "Joe", Salary = 499999 },
    new Employee(){ Id = 4, Age = 50, Name = "Joe", Salary = 4999999 },
    new Employee(){ Id = 5, Age = 60, Name = "Joe", Salary = 49999999 },
};

var results = from e in employees
                   where e.Age > 30
                   orderby e.Name
                   select new { e.Name, e.Age };

Console.WriteLine("Employees over 30 who make more than $5000");
foreach(var e in results)
{
    Console.WriteLine($"Name: {e.Name} Age: {e.Age}");
}

//3.Write a program in C# Sharp to find a string
//that starts and ends with a specific character.

string[] testData = { "ROME", "LONDON", "NAIROBI", "CALIFORNIA", "ZURICH", "NEW DELHI", "AMSTERDAM", "ABU DHABI", "PARIS" };
var questionThreeAnswer = from test in testData
                          where test.StartsWith("A") && test.EndsWith("M")
                          select test;

Console.WriteLine($"The city starting with A and ending with M is {string.Join(",", questionThreeAnswer)}");


//4.Write a program in C# Sharp to create a list of numbers
//and display numbers greater than 80.


int[] BigNumbers = { 55, 200, 740, 76, 230, 482, 95 };
var questionFourAnswer = from BigNumber in BigNumbers
                         where BigNumber > 80
                         select BigNumber;
Console.WriteLine("The numbers greater than 80 are : ");
foreach(var a in questionFourAnswer)
{
    Console.WriteLine(a);
}