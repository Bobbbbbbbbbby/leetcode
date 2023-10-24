namespace leetcode.problem5;

public class Solution {
    public string LongestPalindrome(string s)
    {
        int maxLength = 1; 
        int startOfMax = 0;
        int endOfMax = 1;       // not included
        for(int i = 0; i < s.Length; i++)
        {
            int start = i;
            int end = i + 1;
            while(start - 1 >= 0 && end < s.Length)
            {
                if(s[start - 1] == s[end])
                {
                    start -= 1;
                    end += 1;
                }
                else
                    break;
            }
            int oddStart = start;
            int oddEnd = end;
            int oddLenMax = end - start;
            
            start = i;
            end = i + 1;
            if(end >= s.Length || s[start] != s[end])
            {
                if(oddLenMax > maxLength)
                {
                    startOfMax = oddStart;
                    endOfMax = oddEnd;
                    maxLength = oddLenMax;
                }
                continue;
            }
            end += 1;
            while(start - 1 >= 0 && end < s.Length)
            {
                if(s[start - 1] == s[end])
                {
                    start -= 1;
                    end += 1;
                }
                else
                    break;
            }
            int evenStart = start;
            int evenEnd = end;
            int evenLenMax = end - start;
            
            int thisRoundMaxLength;
            int thisRoundStartOfMax;
            int thisRoundEndOfMax;
            if(oddLenMax > evenLenMax)
            {
                thisRoundMaxLength = oddLenMax;
                thisRoundStartOfMax = oddStart;
                thisRoundEndOfMax = oddEnd;
            }
            else
            {
                thisRoundMaxLength = evenLenMax;
                thisRoundStartOfMax = evenStart;
                thisRoundEndOfMax = evenEnd;
            }
            
            if(thisRoundMaxLength > maxLength)
            {
                maxLength = thisRoundMaxLength;
                startOfMax = thisRoundStartOfMax;
                endOfMax = thisRoundEndOfMax;
            }
        }
        
        return s.Substring(startOfMax, endOfMax - startOfMax);
    }
}

// Analyze: AxB is a palindrome