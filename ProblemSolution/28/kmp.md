# KMP Algorithm
## Prefix Table
which record the length of the longest same real prefix and real suffix of every substring.

For example, for string S = "aabaaf"
* sub = "a", no prefix and suffix. next[0] = 0
* sub = "aa", pre = "a", suf = "a". next[1] = 1
* sub = "aab", next[2] = 0
* sub = "aaba", pre = "a", suf = "a". next[3] = 1
* sub = "aabaa", pre = "aa", suf = "aa". next[4] = 2
* sub = "aabaaf", next[5] = 0

## Get Prefix Table
```c
    public void GetNext(string needle, int[] next) {
        next[0] = 0;
        int j = 0;
        for(int i = 1; i < next.Length; i++) {  // i point to end of substring, as well as end of suffix
            while (j > 0 && needle[j] != needle[i]) // j point to end of prefix
                j = next[j - 1];
            if (needle[j] == needle[i])
                j++;
            next[i] = j;
        }
    }
```
* If substring length is 1, no real prefix and suffix
* Use a loop to get prefix table
  * In last loop, for the substring(len = i + 1), prefix(len = j) match suffix(len = j)
  * In this loop, for the len = (i + 1) substring,
    * If needle[j] = needle[i], prefix(len = j + 1) match suffix(len = j + 1)
    * If needle[j] != needle[i], prefix(len = j + 1) not match suffix(len = j + 1)
    * Then we need to find a shorter prefix-suffix pair of substring(length = i)
    * Because the prefix and suffix is the same, the shorter suffix is also the suffix of the original suffix, find this shorter prefix-suffix pair means find the prefix-suffix pair of substring(len = j). Length of the shorter prefix-suffix pair is in next[j - 1]. So j = next[j - 1].
    * Now check whether the new prefix(len = j + 1) match the new suffix(len = j + 1). If so, we find the length of longest prefix-suffix pair for substring(len = i + 1).

## Use the next array
```c
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
```
Loop to find the first match string
* If match, forward both i and j.(i point to elements in main string, j points to elements in substring)
* If not match, use same method find shorter prefix-suffix pair like GetNext
  * This loop may jump out because of j = 0 or because of needle[j] = haystack[i]
  * If reason is j = 0 and needle[j] != haystack[i], forward i but j stays. Compare haystack[i + 1] with needle[0]
  * If reason is needle[j] = haystack[i], do not do anything in this loop. Match logic will handle in next loop.
* If the outer loop is finished but not return, this means we find no match. Then return -1.