using System;
using leetcode.common;

namespace leetcode.ProblemSolution._24;

public class Solution
{
    public ListNode SwapPairs(ListNode head) {
        if(head == null)
            return head;
        else if(head.next == null)
            return head;

        ListNode nextPair = head;
        ListNode prevPairEnd = null;
        while(true) {
            ListNode pair = nextPair;
            if(pair.next.next == null) {
                ListNode node1 = pair;
                ListNode node2 = pair.next;
                if(prevPairEnd == null) {
                    head = node2;
                    head.next = node1;
                    head.next.next = null;
                    return head;
                }
                else {
                    prevPairEnd.next = node2;
                    prevPairEnd.next.next = node1;
                    prevPairEnd.next.next.next = null;
                    return head;
                }
            }
            else if(pair.next.next.next == null) {
                ListNode node1 = pair;
                ListNode node2 = pair.next;
                ListNode node3 = pair.next.next;
                if(prevPairEnd == null) {
                    head = node2;
                    head.next = node1;
                    head.next.next = node3;
                    return head;
                }
                else {
                    prevPairEnd.next = node2;
                    prevPairEnd.next.next = node1;
                    prevPairEnd.next.next.next = node3;
                    return head;
                }
            }
            else {
                ListNode node1 = pair;
                ListNode node2 = pair.next;
                nextPair = node2.next;
                if(prevPairEnd == null) {
                    head = node2;
                    head.next = node1;
                    head.next.next = nextPair;
                    prevPairEnd = node1;
                }
                else {
                    prevPairEnd.next = node2;
                    prevPairEnd.next.next = node1;
                    prevPairEnd = node1;
                }
            }
        }
    }
}
