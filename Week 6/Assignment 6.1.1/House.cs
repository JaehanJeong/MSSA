using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_6._1._1
{
    class House
    {
        public int HouseNumber { get; set; }
        public string? Address { get; set; }
        public string? HouseType { get; set; }
    }


    internal class Node
    {
        public House Data { get; set; }
        public Node? Next;

        public Node (House val)
        {
            Data = val;
            Next = null;
        }
    }
    class HouseLinkedList
    {
        private Node head;
        private Node tail;
        private int size;

        public int Size { get { return size; } }
        
        public HouseLinkedList()
        {
            this.head = null;
            this.tail = null;
            this.size = 0;
        }

        public bool IsEmpty()
        {
            return this.Size == 0;
        }

        public void AddFirst(House val)
        {
            Node newNode = new Node(val);

            if (IsEmpty())
            {
                this.head = newNode;
                this.tail = newNode;
            }
            else
            {
                newNode.Next = head;
                head = newNode;
            }

            size++;
        }

        public void Display()
        {
            Node? temp = head;

            if (IsEmpty())
            {
                Console.WriteLine("The list is empty.");
                return;
            }

            while (temp != null)
            {
                Console.WriteLine($"House Number: {temp.Data.HouseNumber} ");
                Console.WriteLine($"Address : {temp.Data.Address} ");
                Console.WriteLine($"House Type : {temp.Data.HouseType} ");
                Console.WriteLine();
                temp = temp.Next;
            }
        }

        public House? Search(int houseNumber)
        {
            Node? temp = head;
            if (IsEmpty())
            {
                Console.WriteLine("List is empty");
                return null;
            }
            while (temp != null)
            {
                if (temp.Data.HouseNumber == houseNumber) return temp.Data;
                temp = temp.Next;
            }
            return null;
        }

        public void AddLast(House val)
        {
            Node newNode = new Node(val); // always the first step
            if (IsEmpty())
            {
                this.head = newNode;
                //this.tail = newNode;
            }
            else
            {
                this.tail.Next = newNode;
                //this.tail = newNode;
            }
            this.tail = newNode;
            size++; // whenever you add, you gota increment the size.
        }

        public House RemoveFirst()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Linked list is empty.");
            }
            House val = head.Data; // store this to return val back if needed.
            this.head = head.Next;
            size--; // Very important (controls the isEmpty condition)

            //if there was only 1 node in the list, the size will become 0
            if (IsEmpty())
            {
                tail = null;// Only if 1 node was present and we deleted that, then tail should be updated.
            }
            return val;
        }

        public House RemoveLast()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("List is empty!");
            }
            Node? temp = head;
            int i = 1; // counter to go till size -1

            if(size == 1) //In case there is only one node.
            {
                House removedHouse = head.Data;
                head = null;
                tail = null;
                size--;
                return removedHouse;
            }

            while (i < size - 1)//traverse till second last node
            {
                temp = temp.Next;
                i++;
            }
            //temp is pointing to the second last node
            House val = tail.Data;
            tail = temp; //update the tail to point to the second last node.
            tail.Next = null; // remove the existing last node link.
            size--;//we're removing something from the list.

            if (IsEmpty())//if there was only 1 node and we removed it
            {
                head = null;
            }
            return val;
        }

        public void AddAnywhere(House val, int position)
        {
            if (position <= 0 || position > size + 1)
            {
                Console.WriteLine("Position is invalid.");
                return;
            }
            if (position == 1)
            {
                AddFirst(val);
                return;
            }
            if (position == size + 1)
            {
                AddLast(val);
                return;
            }

            Node newNode = new Node(val);
            Node? temp = head;
            int i = 1;
            while (i < position - 1)
            {
                temp = temp.Next;
                i++;
            }//temp is pointing to a node before the position where new node is to be added.
            newNode.Next = temp.Next; // we store address of next node in newNode's next.
            temp.Next = newNode;//We store address of new node in temp's next - previous
            size++;
        }

        public House RemoveAnywhere(int position)
        {
            if (position <= 0 || position > size)
            {
                throw new InvalidOperationException("Invalid position.");
            }
            if (position == 1) // first element
            {
                return RemoveFirst();
            }
            if (position == size) // last element
            {
                return RemoveLast();
            }
            Node? temp = head;
            int i = 1;
            while (i < position - 1)
            {//we are at position right before
                //holding the value temporarily before we delete it
                temp = temp.Next;
                i++;
            }
            House val = temp.Next.Data;
            temp.Next = temp.Next.Next; // skips the node in between
            size--;
            return val;

        }
    }
}
