namespace MinimumInsertionStepsMakeStringPalindrome
{
    internal class Program
    {
        public class MinimumInsertionStepsMakeStringPalindrome
        {
            private int DFS(string s1, string s2, int m, int n, int[,] dp)
            {
                if (m == 0 || n == 0)
                {
                    return 0;
                }
                if (dp[m, n] != -1)
                {
                    return dp[m, n];
                }
                if (s1[m - 1] == s2[n - 1])
                {
                    dp[m, n] = 1 + DFS(s1, s2, m - 1, n - 1, dp);
                }
                else
                {
                    dp[m, n] = Math.Max(DFS(s1, s2, m - 1, n, dp), DFS(s1, s2, m, n - 1, dp));
                }
                return dp[m, n];
            }

            public int MinInsertions(string s)
            {
                int n = s.Length;
                string reverseStr = new(s.Reverse().ToArray());
                int[,] dp = new int[n + 1, n + 1];
                for (int i = 0; i <= n; ++i)
                {
                    for(int j = 0; j <= n; ++j)
                    {
                        dp[i, j] = -1;
                    }
                }
                return n - DFS(s, reverseStr, n, n, dp);
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