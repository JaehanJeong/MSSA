using Assignment_6._2._1;

// Initialize a new instance of our Stack
StackLL stack = new();

// Add three items to the stack (3456 will be on top)
stack.Push(1234);
stack.Push(2345);
stack.Push(3456);

Console.WriteLine("Here's what we have so far : ");
stack.Display();

Console.WriteLine();

// Remove the top item (3456)
stack.Pop();
Console.WriteLine("Popping..."); 

Console.WriteLine("Stack after pop:");
stack.Display();