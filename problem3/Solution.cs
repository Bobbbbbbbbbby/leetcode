namespace leetcode.problem3;

public class Solution {
    public int LengthOfLongestSubstring(string s)
    {
        if(s.Length == 0)
            return 0;
        var startPoint = 0;
        var endPoint = 1; // not included
        var maxLen = 1;
        var currentLen = 1;
        
        while (endPoint < s.Length)
        {
            char letter = s[endPoint];
            var repeatMark = false;
            for(var i = startPoint; i < endPoint; i++)
            {
                if(letter == s[i])
                {
                    if(currentLen > maxLen)
                        maxLen = currentLen;
                    startPoint = i + 1;
                    currentLen = endPoint - startPoint;
                    repeatMark = true;
                    break;
                }
            }
            if(!repeatMark)
            {
                currentLen++;
                endPoint++;
            }
        }
        return (currentLen > maxLen) ? currentLen : maxLen;
    }
}