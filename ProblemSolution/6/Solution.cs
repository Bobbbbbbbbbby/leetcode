namespace leetcode.ProblemSolution._6;

public class Solution
{
    public string Convert(string s, int numRows)
    {
        // rowIdx record the current row
        // idx is for the generated string
        // inLineIdx表示行内的组号，第一行和最后一行每组1个，中间行每组两个
        if(numRows == 1)
            return s;
        char[] result = new char[s.Length];
        var rowIdx = 0;
        var idx = 0;
        while(idx < s.Length)
        {
            if(rowIdx == 0 || rowIdx == numRows - 1)
            {
                // var inLineIdx = 0;
                var originIdx = rowIdx;
                while(originIdx < s.Length)
                {
                    result[idx++] = s[originIdx];
                    originIdx += 2 * (numRows - 1);
                }
                rowIdx++;
            }
            else
            {
                // var inLineIdx = 0;
                var originIdx1 = rowIdx;
                var originIdx2 = 2 * (numRows - 1) - rowIdx;
                while(originIdx1 < s.Length)
                {
                    result[idx++] = s[originIdx1];
                    if(originIdx2 < s.Length)
                    {
                        result[idx++] = s[originIdx2];
                    }
                    else
                        break;
                    originIdx1 += 2 * (numRows - 1);
                    originIdx2 += 2 * (numRows - 1);
                }
                rowIdx++;
            }
        }
        string ret = new string(result);
        return ret;
    }
}

/*
0.        10.            20
1.      9 11.         19
2.    8.  12.      18
3   7.    13.   17
4 6.      14 16
5.        15

row 0: 2 * n * (numRows - 1), ...
row 1: 2 * n * (numRows - 1) + 1, 2 * (n + 1) * (numRows - 1) - 1, ...
row 2: 2 * n * (numRows - 1) + 2, 2 * (n + 1) * (numRows - 1) - 2
*/