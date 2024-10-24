// See https://aka.ms/new-console-template for more information

namespace leetcode;

using ProblemSolution._28;
class Debug
{
    static void Main()
    {
        /* test data */
        string S = "hello";
        string T = "ll";

        var solution = new Solution();
        int result = solution.StrStr(S, T);

        // output result
        Console.WriteLine(result);
    }
}
