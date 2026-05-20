using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_7._3
{
    internal class Node
    {
        public int Data { get; set;  }
        public Node left;
        public Node right;
        public Node(int data)
        {
            this.Data = data;
            this.left = null;
            this.right = null;
        }
    }

    class BinarySearchTree
    {
        private Node root;
        public Node Root
        {
            get { return this.root; }
        }
        public BinarySearchTree()
        {
            this.root = null;
        }

        public void Add(int val, Node tempRoot)
        {
            Node newNode = new Node(val);
            Node temp = null;
            if(this.root != null)
            {
                while(tempRoot!=null)
                {
                    temp = tempRoot;
                    if(tempRoot.Data == val)
                    {
                        Console.WriteLine("Duplicate found ");
                        return;
                    }
                    else if (val < tempRoot.Data)
                    {
                        tempRoot = tempRoot.left;
                    }
                    else
                    {
                        tempRoot = tempRoot.right;
                    }
                }
                if (val < temp.Data)
                {
                    temp.left = newNode;
                }
                else
                {
                    temp.right = newNode;
                }
            }
            else
            {
                this.root = newNode;
            }
  
        }

        public void InOrder(Node tempRoot)
        {
            if(tempRoot != null)
            {
                InOrder(tempRoot.left);
                Console.Write(tempRoot.Data + " ");
                InOrder(tempRoot.right);
            }
        }

        public bool Search(int val)
        {
            Node temp = this.root;
            while(temp!=null)
            {
                if(temp.Data == val)
                {
                    Console.WriteLine($"Subtree rooted with that node is {temp.Data}");
                    return true;
                }
                else if (val < temp.Data)
                {
                    temp = temp.left;
                }
                else
                {
                    temp = temp.right;
                }
            }
            return false;
        }
    }
}
