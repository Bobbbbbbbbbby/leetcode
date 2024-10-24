using System;

namespace leetcode.ProblemSolution._28;

public class Solution
{
    public int StrStr(string haystack, string needle)
    {
        int needle_len = needle.Length;
        int[] next = new int[needle_len];
        GetNext(needle, next);
        int i = 0;
        int j = 0;
        while (i < haystack.Length)
        {
            if (needle[j] == haystack[i])
            {
                if (j == needle.Length - 1)
                    return i - j;
                j++;
                i++;
                continue;
            }
            while (j > 0 && needle[j] != haystack[i])
                j = next[j - 1];
            if (j == 0 && needle[j] != haystack[i])
            {
                i++;
            }
        }
        return -1;
    }

    private void GetNext(string needle, int[] next)
    {
        next[0] = 0;
        int j = 0;
        for (int i = 1; i < next.Length; i++)
        {  // i point to end of substring, as well as end of suffix
            while (j > 0 && needle[j] != needle[i]) // j point to end of prefix
                j = next[j - 1];
            if (needle[j] == needle[i])
                j++;
            next[i] = j;
        }
    }
}
