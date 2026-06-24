using System;
using System.Collections.Generic;
using System.Text;

namespace Remove_Linked_List_Elements
{
    public ListNode RemoveElements(ListNode head, int givenValue)
    {
        // If head is null or head has the bad value, redirect to the next node.
        while (head != null && head.val == givenValue)
        {
            head = head.next;
        }

        // Officially start our head / linked list.
        ListNode current = head;

        // Assuming we aren't at the very end nor penultimate node,
        while (current != null && current.next != null)
        {
            //If our next node is the bad value
            if (current.next.val == givenValue)
            {
                // redirect it to the one after.
                current.next = current.next.next;
            }
            else
            {
                // If nothing's wrong then continue mission
                current = current.next;
            }
        }
        //Gives the linked list back by pointing to its head.
        return head;
    }
}
