using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtCoderKyoupro90
{
    class _008_AtCounter
    {
        public void Run_origin()
        {
            int mod = 1000000007;
            string atcorder = "atcoder";
            string input = Console.ReadLine();
            var dp = new long[input.Length + 1][];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new long[atcorder.Length + 1];
            }
            dp[0][0] = 1;
            for (int i = 0; i < input.Length; i++)
            {
                //for (int j = 0; j < atcorder.Length; j++)
                for (int j = 0; j < atcorder.Length+1; j++)
                {
                    dp[i + 1][j] += dp[i][j];
                    if (input[i] == 'a' && j == 0) dp[i + 1][j + 1] += dp[i][j];
                    if (input[i] == 't' && j == 1) dp[i + 1][j + 1] += dp[i][j];
                    if (input[i] == 'c' && j == 2) dp[i + 1][j + 1] += dp[i][j];
                    if (input[i] == 'o' && j == 3) dp[i + 1][j + 1] += dp[i][j];
                    if (input[i] == 'd' && j == 4) dp[i + 1][j + 1] += dp[i][j];
                    if (input[i] == 'e' && j == 5) dp[i + 1][j + 1] += dp[i][j];
                    if (input[i] == 'r' && j == 6) dp[i + 1][j + 1] += dp[i][j];
                    //if (input[i] == atcorder[j])
                    //{
                    //    dp[i + 1][j + 1] += dp[i][j];
                    //}
                }
            }
            Console.WriteLine(dp[input.Length][atcorder.Length] % mod);
        }
    }
}
