namespace leetcode.problem2;

public class Solution
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        ListNode? worker1 = l1;
        ListNode? worker2 = l2;
        var carry = 0;
        while(true)
        {
            var sum = worker1.Val + worker2.Val + carry;
            if(sum >= 10)
            {
                worker1.Val = sum - 10;
                carry = 1;
            }
            else
            {
                worker1.Val = sum;
                carry = 0;
            }

            if (worker1.Next == null || worker2.Next == null)
                break;
            worker1 = worker1.Next;
            worker2 = worker2.Next;
        }

        worker1.Next ??= worker2.Next;
        // if left is not empty then left will not change
        // if left is empty then left will be assigned with the value of right

        while(worker1.Next != null && carry == 1)
        {
            worker1 = worker1.Next;
            int sum = worker1.Val + carry;
            if(sum >= 10)
            {
                worker1.Val = sum - 10;
                carry = 1;
            }
            else
            {
                worker1.Val = sum;
                carry = 0;
            }
        }

        if (worker1.Next == null && carry == 1)
        {
            worker1.Next = new ListNode(1);
        }
        return l1;
    }
}