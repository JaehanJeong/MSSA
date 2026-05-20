using System;
using System.Collections.Generic;
using System.Text;

namespace Merge_Two_Sorted_Lists
{
    public class Solution
    {
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            ListNode dummy = new(0);
            ListNode current = dummy;

            while (list1 != null && list2 != null)
            {
                if (list1.val < list2.val)
                {
                    current.next = list1;
                    list1 = list1.next;
                }
                else
                {
                    current.next = list2;
                    list2 = list2.next;
                }
                current = current.next;
            }
            if (list1 == null)
            {
                current.next = list2;
            }
            if (list2 == null)
            {
                current.next = list1;
            }
            return dummy.next;
        }
    }
}
