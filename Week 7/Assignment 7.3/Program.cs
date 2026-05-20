using Assignment_7._3;

BinarySearchTree tree = new();

tree.Add(20, tree.Root); // root is null
tree.Add(10, tree.Root); // root is 20
tree.Add(45, tree.Root);
tree.Add(100, tree.Root);
tree.Add(4, tree.Root);

int val = 45;

tree.Search(val);