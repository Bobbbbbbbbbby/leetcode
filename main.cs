// See https://aka.ms/new-console-template for more information

namespace leetcode;

using problem5;
class Run
{
    static void Main()
    {
        var s = "bacabab";
        var solution = new Solution();
        Console.WriteLine(solution.LongestPalindrome(s));
    }
}
