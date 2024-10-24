namespace leetcode.ProblemSolution._2;
using leetcode.common;

public class Solution
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        ListNode? worker1 = l1;
        ListNode? worker2 = l2;
        var carry = 0;
        while(true)
        {
            var sum = worker1.val + worker2.val + carry;
            if(sum >= 10)
            {
                worker1.val = sum - 10;
                carry = 1;
            }
            else
            {
                worker1.val = sum;
                carry = 0;
            }

            if (worker1.next == null || worker2.next == null)
                break;
            worker1 = worker1.next;
            worker2 = worker2.next;
        }

        worker1.next ??= worker2.next;
        // if left is not empty then left will not change
        // if left is empty then left will be assigned with the value of right

        while(worker1.next != null && carry == 1)
        {
            worker1 = worker1.next;
            int sum = worker1.val + carry;
            if(sum >= 10)
            {
                worker1.val = sum - 10;
                carry = 1;
            }
            else
            {
                worker1.val = sum;
                carry = 0;
            }
        }

        if (worker1.next == null && carry == 1)
        {
            worker1.next = new ListNode(1);
        }
        return l1;
    }
}