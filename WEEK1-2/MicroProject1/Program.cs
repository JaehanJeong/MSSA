//Goal: Create a simple application to manage the membership of a club.

//Classes: Create a base class and two derived classes for data about regular members and club board members.

//Methods:
//Create a method to enroll a new member.
//Create a method to make a regular member a board member.
//Create a method to list all members.

//Data
//Create a mock data list of three members. One should be a board member.
//From 1234 till 1400.

using MicroProject1.Models;


Club.ListMembers();
Club.PromoteToBoard(1);
Console.WriteLine();

Console.WriteLine();
Console.WriteLine($"{Club.GetMemberById(1).Name} is being promoted to Board Member...");
Club.ListMembers();