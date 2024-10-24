using System;
using System.Globalization;

namespace leetcode.ProblemSolution._26;

public class Solution
{
    public int RemoveDuplicates(int[] nums)
    {
        int k = 1;
        int curr = nums[0];
        for(int i = 1; i < nums.Length; i++) {
            if(nums[i] != curr) {
                nums[k] = nums[i];
                curr = nums[k];
                k++;
            }
        }
        return k;
    }
}
