public class Solution
{
    public ListNode DeleteDuplicates(ListNode head)
    {
        if (head == null) return null;

        ListNode current = head;

        while (current != null && current.next != null)
        {
            if (current.val == current.next.val)
                current.next = current.next.next; // skip the duplicate
            else
                current = current.next; // only move forward if no duplicate found
        }

        return head;
    }
}