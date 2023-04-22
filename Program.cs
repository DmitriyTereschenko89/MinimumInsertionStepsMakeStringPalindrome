namespace MinimumInsertionStepsMakeStringPalindrome
{
    internal class Program
    {
        public class MinimumInsertionStepsMakeStringPalindrome
        {
            private int[,] dp;

            private int DFS(string s1, string s2, int m, int n)
            {
                if (m == 0 || n == 0)
                {
                    return 0;
                }
                if (dp[m, n] != -1)
                {
                    return dp[m, n];
                }
                if (s1[m] == s2[n])
                {
                    dp[m, n] = 1 + DFS(s1, s2, m - 1, n - 1);
                }
                else
                {
                    dp[m, n] = Math.Max(DFS(s1, s2, m - 1, n), DFS(s1, s2, m, n - 1));
                }
                return dp[m, n];
            }

            public int MinInsertions(string s)
            {
                int n = s.Length;
                string reverseStr = new string(s.Reverse().ToArray());
                dp = new int[n + 1, n + 1];
                for (int i = 0; i <= n; ++i)
                {
                    dp[i, i] = -1;
                }
                return n - DFS(s, reverseStr, n, n);
            }
        }

        static void Main(string[] args)
        {
            MinimumInsertionStepsMakeStringPalindrome minimumInsertionStepsMakeStringPalindrome = new();
            Console.WriteLine(minimumInsertionStepsMakeStringPalindrome.MinInsertions("zzazz"));
            Console.WriteLine(minimumInsertionStepsMakeStringPalindrome.MinInsertions("mbadm"));
            Console.WriteLine(minimumInsertionStepsMakeStringPalindrome.MinInsertions("leetcode"));
        }
    }
}