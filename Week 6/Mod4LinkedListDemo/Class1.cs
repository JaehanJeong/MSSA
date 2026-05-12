using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Mod4LinkedListDemo
{
    class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
    }

    internal class Node
    {
        public int Data { get; set; }
        public Node next;

        public Node(int val)
        {
            Data = val;
            next = null;
        }
    } // <- CLOSE NODE CLASS HERE

    class LinkedList
    {
        private Node head;
        private Node tail;
        private int size;

        public int Size { get { return size; } }

        public LinkedList()
        {
            this.head = null;
            this.tail = null;
            this.size = 0;
        }

        public bool IsEmpty()
        {
            return this.size == 0;
        }

        public void AddFirst(int val)
        {
            Node newNode = new Node(val);

            if (IsEmpty())
            {
                this.head = newNode;
                this.tail = newNode;
            }
            else
            {
                newNode.next = head;
                head = newNode;
            }

            size++;
        }

        //O(n)
        public void Display()
        {
            Node temp = head;

            if (IsEmpty())
            {
                Console.WriteLine("The list is empty.");
                return;
            }

            while (temp != null)
            {
                Console.Write(temp.Data + " ");
                temp = temp.next;
            }
        }

        //O(n)
        public bool Search(int val)
        {
            Node temp = head;
            if (IsEmpty())
            {
                Console.WriteLine("List is empty");
                return false;
            }
            while (temp != null)
            {
                if (temp.Data == val) return true;
                temp = temp.next;
            }
            return false;
        }

        //O(1)
        public void AddLast(int val)
        {
            Node newNode = new Node(val); // always the first step
            if (IsEmpty())
            {
                this.head = newNode;
                //this.tail = newNode;
            }
            else
            {
                this.tail.next = newNode;
                //this.tail = newNode;
            }
            this.tail = newNode;
            size++; // whenever you add, you gota increment the size.
        }

        //O(1)
        public int RemoveFirst()
        {
            if(IsEmpty())
            {
                throw new InvalidOperationException("Linked list is empty.");
            }
            int val = head.Data; // store this to return val back if needed.
            this.head = head.next;
            size--; // Very important (controls the isEmpty condition)

            //if there was only 1 node in the list, the size will become 0
            if(IsEmpty())
            {
                tail = null;// Only if 1 node was present and we deleted that, then tail should be updated.
            }
            return val;
        }

        //O(n) because theres a while loop to find penultimate
        public int RemoveLast()
        {
            if(IsEmpty())
            {
                throw new InvalidOperationException("List is empty!");
            }
            Node temp = head;
            int i = 1; // counter to go till size -1
            while (i<size-1)//traverse till second last node
            {
                temp = temp.next;
                i++;
            }
            //temp is pointing to the second last node
            int val = tail.Data;
            tail = temp; //update the tail to point to the second last node.
            tail.next = null; // remove the existing last node link.
            size--;//we're removing something from the list.

            if(IsEmpty())//if there was only 1 node and we removed it
            {
                head = null;
            }
            return val;
        }
        
        //O(n) because theres a while loop
        public void AddAnywhere(int val, int position)
        {
            if(position <= 0 || position>size+1)
            {
                Console.WriteLine("Position is invalid.");
            }
            if(position==1)
            {
                AddFirst(val);
                return;
            }
            if(position == size+1)
            {
                AddLast(val);
                return;
            }

            Node newNode = new Node(val);
            Node temp = head;
            int i = 1;
            while (i < position - 1)
            {
                temp = temp.next;
                i++;
            }//temp is pointing to a node before the position where new node is to be added.
            newNode.next = temp.next; // we store address of next node in newNode's next.
            temp.next = newNode;//We store address of new node in temp's next - previous
            size++;
        }


        //O(n) linear cuz we're looping.
        public int RemoveAnywhere(int position)
        {
            if(position<= 0 || position>size)
            {
                throw new InvalidOperationException("Invalid position.");
            }
            if(position == 1) // first element
            {
                return RemoveFirst();
            }
            if(position == size) // last element
            {
                return RemoveLast();
            }
            Node temp = head;
            int i = 1;
            while(i<position-1)
            {//we are at position right before
                //holding the value temporarily before we delete it
                temp = temp.next;
                i++;
            }
            int val = temp.next.Data;
            temp.next = temp.next.next; // skips the node in between
            size--;
            return val;

        }
    }
}
