using System;
using leetcode.common;

namespace leetcode.ProblemSolution._25;

public class Solution
{
    public ListNode ReverseKGroup(ListNode head, int k)
    {
        if (k == 1)
            return head;
        if (head == null)
            return head;
        if (head.next == null)
            return head;

        // count how many elements in link list
        int count = 0;
        ListNode worker = head;
        while(worker != null) {
            count++;
            worker = worker.next;
        }

        // create an array to locate list node
        ListNode[] arr = new ListNode[count];
        worker = head;
        for(int i = 0; i < count; i++) {
            arr[i] = worker;
            worker = worker.next;
        }

        // count/k time reverse is needed
        int time = count / k;
        int tail_count = count % k;
        ListNode prevEnd = null;
        for(int i = 0; i < time; i++) {
            ListNode start = arr[i * k];
            ListNode end = arr[(i + 1) * k - 1];
            if(i == 0) {
                head = end;
                prevEnd = start;
                worker = head;
                for(int j = 0; j < k - 1; j++) {
                    worker.next = arr[(i + 1) * k - 1 - (j + 1)];
                    worker = worker.next;
                }
                worker.next = null;
                if (i == time - 1 && tail_count != 0)
                {
                    worker.next = arr[(i + 1) * k];
                    break;
                }
                else if (i == time - 1)
                {
                    break;
                }
            }
            else {
                worker = prevEnd;
                for(int j = 0; j < k; j++) {
                    worker.next = arr[(i + 1) * k - 1 - j];
                    worker = worker.next;
                }
                worker.next = null;
                prevEnd = start;
                if(i == time - 1 && tail_count != 0) {
                    worker.next = arr[(i + 1) * k];
                    break;
                }
                else if(i == time - 1) {
                    break;
                }
            }
        }
        return head;
    }
}
