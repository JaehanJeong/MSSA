using Mod8BSTDemo;

BinarySearchTree tree = new();
tree.Add(20, tree.Root); // root is null
tree.Add(10, tree.Root); // root is 20
tree.Add(45, tree.Root);
tree.Add(100, tree.Root);
tree.Add(4, tree.Root);
Console.WriteLine("In order traversal");
tree.InOrder(tree.Root);

Console.WriteLine();
Console.WriteLine("Pre order traversal");
tree.PreOrder(tree.Root);

Console.WriteLine();
Console.WriteLine("Post order traversal");
tree.PostOrder(tree.Root);
