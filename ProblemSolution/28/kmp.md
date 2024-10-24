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