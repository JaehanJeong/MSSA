/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution
{
    public bool IsPalindrome(ListNode head)
    {
        // Let's start at the head
        ListNode current = head;
        // values list is where we'll add our values
        List<int> values = new();

        // Continue until current is null
        while (current != null)
        {
            //add the current value to values list
            values.Add(current.val);

            //move to the next node
            current = current.next;
        }
        //Done populating the list

        // We'll now use two pointers to check if the list is a palindrome
        int i = 0; // Start of our values list
        int j = values.Count - 1;// End of our values list
        // Ensure we're only going half way.
        while (i < j)
        {
            if (values[i] != values[j]) // Exit early if they're different.
            {
                return false;
            }
            i++; // Move front pointer forward
            j--; // Move ending? pointer backwards.
        }
        return true; // If we pass all, then must be a palindrome! :D

    }
}