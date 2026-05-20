using System.IO;
namespace Mod3Enumdemo
{
    // Write enum in the namespace so that it's available to all the classes

    enum ErrorCode
    {
        //has to be just words and not in quotes.
        Notaccessible = 100, // first one by default is 0, but you can assign value like this.
        SystemCrash // second would be 1 by default. But if Notaccessible starts at 100, this would be 101
    }
    enum Department
    {
        // Enums limit user entry, thus preventing potential errors.
        // This could become a master table in your data base.
        HR = 1,
        Marketing = 2,
        IT = 3,
        Finance
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.BackgroundColor = ConsoleColor.Cyan;
            //FileStream fileStream = new FileStream("c:\demo.txt", FileMode.Open); 2 nums that are available

            // Declaring List. 
            List<ToDo> todos = new List<ToDo>();
            //Syntax: List(keyword) <> (data type in the list)  todos (name) = (assigned to) new (new instance) List of ToDo()

            //Adding to the To Do List
            todos.Add(new ToDo() { TaskId = 1, Description = "Do Assignment 3.4", EstimatedHours = 2.5f, TaskStatus = Status.NotStarted });
            //Highly type safe collection class.

            todos.Add(new ToDo() { TaskId = 2, Description = "Quiz", EstimatedHours = 0.5f, TaskStatus = Status.Dismissed });
            todos.Add(new ToDo() { TaskId = 3, Description = "Study", EstimatedHours = 5.5f, TaskStatus = Status.InProgress });
            todos.Add(new ToDo() { TaskId = 4, Description = "Do the Challenge Labs", EstimatedHours = 2.5f, TaskStatus = Status.OnHold });
            todos.Add(new ToDo() { TaskId = 5, Description = "LinkedIn Profile Creation", EstimatedHours = 1.5f, TaskStatus = Status.Completed });
            PrintList(todos);

            Book book1 = new Book();
            book1.BookId = 101;
            //ChangeId(book1);
            //Console.WriteLine($"{book1.BookId}");

            BookCls book2 = new BookCls();
            book2.BookId = 102;

            ChangeId(book2);
            Console.WriteLine($"{book2.BookId}");
        }
        static Book ChangeId (Book b)
        {
            b.BookId = 200;
            return b;
        }

        static void PrintList(List<ToDo> tasks)
        {
            foreach (var todo in tasks)
            {
                {
                    switch (todo.TaskStatus)
                    {
                        case Status.NotStarted:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                        case Status.Completed:
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                        case Status.Dismissed:
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            break;
                        case Status.InProgress:
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            break;
                        case Status.OnHold:
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            break;
                    }
                    Console.WriteLine($"{todo.TaskId}, ({todo.Description}, {todo.EstimatedHours}, {todo.TaskStatus})");
                }
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}

