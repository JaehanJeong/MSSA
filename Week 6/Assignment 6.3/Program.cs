using Assignment_6._3;

Q myq = new Q();


Customer Jaehan = new("Jaehan", 1, "Live life.");
Customer Matt = new("Matt", 2, "Have fun.");
Customer Daniel = new("Daniel", 3, "Over take the world.");

myq.Enqueue(Jaehan);
myq.Enqueue(Matt);
myq.Enqueue(Daniel);


myq.Display();


Console.WriteLine($"After d q: {myq.Dequeue()}");

Console.WriteLine();

myq.Display();