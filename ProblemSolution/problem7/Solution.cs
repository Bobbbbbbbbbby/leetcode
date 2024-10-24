namespace leetcode.problem7;

public class Solution {
    public int Reverse(int x)
    {
        int target = x > 0 ? x : -x;
        if(target == 0)
            return 0;
        
        long result = 0;
        while(target != 0)
        {
            result *= 10;
            result += target % 10;
            target /= 10;
        }
        
        result = x > 0 ? result : -result;
        // return result >= int.MinValue && result <= int.MaxValue ? (int)result : 0;
        return result is >= int.MinValue and <= int.MaxValue ? (int)result : 0;
    }
}