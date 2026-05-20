using System;
using System.Collections.Generic;
using System.Text;

namespace Mod8BSTDemo
{
    internal class Node
    {
        public int Data { get; set; }
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
        // Pointer to the root of the tree
        // Kept as read-only to avoid manipulating from client code.
        private Node root;
        public Node Root
        {
            get { return this.root; }
        }
        public BinarySearchTree()
        {
            this.root = null;
        }


        //o(logn)
        public void Add(int val,Node tempRoot) // tempRoot points to root, used for navigation
        {
            Node newNode = new Node(val);
            Node temp = null; // trace the last node's location
            if(this.root != null) // tree is not empty
            {
                while(tempRoot!=null)
                {
                    temp = tempRoot;
                    if (tempRoot.Data == val) // Checking for duplicates
                    {
                        Console.WriteLine("Duplicate found.");
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
                //we have reached leaf node
                if(val < temp.Data)
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
                this.root = newNode; // If tree is empty, the new node becomes the root.
            }
        }
        
        // o (n)
        public void InOrder(Node tempRoot)
        {
            if(tempRoot != null) // base condition
            {
                InOrder(tempRoot.left); // Keep checking from left cuz thats InOrder duh
                Console.Write(tempRoot.Data + " "); //Root
                InOrder(tempRoot.right);// Right
            }
        }

        public void PreOrder(Node tempRoot)
        {
            if(tempRoot!=null)
            {
                Console.Write(tempRoot.Data + " ");
                PreOrder(tempRoot.left);
                PreOrder(tempRoot.right);
            }
        }

        public void PostOrder(Node tempRoot)
        {
            if(tempRoot!=null)
            {
                PostOrder(tempRoot.left);
                PostOrder(tempRoot.right);
                Console.Write(tempRoot.Data + " ");
            }
        }

        // o (logn)
        public bool Search(int val)
        {
            Node temp = this.root;
            while(temp!=null)
            {
                if(temp.Data ==val)
                {
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
