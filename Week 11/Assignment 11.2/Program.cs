public class Solution
{
    public ListNode ReverseList(ListNode head)
    {
        // 'prev' will eventually become the new head of the reversed list.
        // We start with 'null' because the original head will become the new tail,
        // and the tail must point to null.
        ListNode prev = null;

        // 'current' is the node we are currently looking at and trying to re-point.
        ListNode current = head;

        // We loop through the list until we run out of nodes (reach the end).
        while (current != null)
        {
            // 1. Store the next node temporarily.
            // If we didn't do this, we would "lose" the rest of the list 
            // the moment we change current.next.
            ListNode nextNode = current.next;

            // 2. Changing the direction
            // Instead of pointing to the next node in the original list,
            // we point it backward to the node behind us.
            current.next = prev;

            // 3. Move pointers forward for the next iteration.
            // 'prev' moves up to the node that just finished processing.
            prev = current;
            // 'current' moves up to the node saved in step 1.
            current = nextNode;
        }

        // After the loop, 'current' is null, and 'prev' is sitting on the 
        // very last node of the original list, which is the new head.
        return prev;
    }
}