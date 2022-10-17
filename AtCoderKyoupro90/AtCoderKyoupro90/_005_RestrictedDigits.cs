using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtCoderKyoupro90
{
    class _005_RestrictedDigits
    {
        public void Run()
        {
            long mod = 1000000007;

            string[] input = Console.ReadLine().Split(" ");
            long N = long.Parse(input[0]);
            int B = int.Parse(input[1]);
            int K = int.Parse(input[2]);

            int[] c = new int[K];
            input = Console.ReadLine().Split(" ");
            for (int i = 0; i < K; i++)
            {
                c[i] = int.Parse(input[i]);
            }

            // 桁DP。上からx桁目のBで割った余りが何通りあるかを動的に格納していく
            long[][] dp = new long[N + 1][];
            for (int i = 0; i < N + 1; i++)
            {
                // Bで割った余り分必要なので長さB（0~B-1まで）
                dp[i] = new long[B];
            }

            // 0桁目は0しかないので1通り？
            dp[0][0] = 1;
            // 1桁目から、Bで割った余りの数のパターンを計上していく
            for (int i = 0; i < N; i++)
            {
                // Bで割ったあまりの数は0~B-1なのでB回ループ
                for (int j = 0; j < B; j++)
                {
                    // 最大で1~9まで。c[0]~c[K-1]までK回ループ
                    for (int k = 0; k < K; k++)
                    {
                        // 前回の余り+c[k]をBで割った余り
                        int nex = (10 * j + c[k]) % B;
                        // i+1桁目でBで割った余りの組み合わせ数に前回の余り分の組み合わせ数を加算
                        dp[i + 1][nex] += dp[i][j];
                        // でかすぎる数を削るため？
                        dp[i + 1][nex] %= mod;
                    }
                }
            }

            // 最終的にN桁目（下一桁）で余り0になる組み合わせの数が答え
            Console.WriteLine(dp[N][0]);

        }

        public void RunFib()
        {
            int n = int.Parse(Console.ReadLine());
            int[] memo = new int[100000];
            int res = Fib(n, memo);
            Console.WriteLine(res);
        }

        int Fib(int n, int[] memo)
        {
            if (n <= 2)
            {
                memo[n] = 1;
                return 1;
            }
            else
            {
                if (memo[n] != 0)
                {
                    return memo[n];
                }
                else
                {
                    memo[n] = Fib(n - 1, memo) + Fib(n - 2, memo);
                    return memo[n];
                }
            }
        }



        // 小森がトライしたが遅すぎて桁が大きいと使えない
        public void Run_komori()
        {
            string[] input = Console.ReadLine().Split(" ");
            long N = int.Parse(input[0]);
            int B = int.Parse(input[1]);
            int K = int.Parse(input[2]);

            int[] c = new int[K];
            input = Console.ReadLine().Split(" ");
            for (int i = 0; i < K; i++)
            {
                c[i] = int.Parse(input[i]);
            }

            // N桁の数の最大値はcの最大値を並べた数
            long max = 0;
            for (int i = 1; i <= N; i++)
            {
                max += c[K - 1] * (long)(Math.Pow(10, i - 1));
            }

            // maxまでの間のBの倍数を抽出
            List<long> multipleBList = new();
            long multipled = 1;
            while (true)
            {
                long multipleB = B * multipled;
                // N桁、かつmax以下
                if ((long)Math.Log10(multipleB) + 1 == N && multipleB <= max)
                {
                    multipleBList.Add(B * multipled);
                }
                else if (multipleB > max)
                {
                    break;
                }
                multipled++;
            }

            // Bの倍数リストがcで表せるかどうかを判定
            int result = 0;
            foreach(long multipleB in multipleBList)
            {
                // 各桁の数値をリストに格納
                List<int> elementList = new();
                long value = multipleB;
                while (0 < value)
                {
                    // 下一桁をリストに格納（既になければ）
                    if (!elementList.Contains((int)value % 10))
                    {
                        elementList.Add((int)value % 10);
                    }
                    // 下一桁を削除
                    value = (value / 10);
                }

                // 各桁の数値すべてがcに含まれればtrue、ひとつでもなければfalse
                bool judge = true;
                foreach(int element in elementList)
                {
                    if (!c.Contains(element))
                    {
                        judge = false;
                        break;
                    }
                }

                // trueならresultを加算
                if (judge)
                {
                    result++;
                }
            }

            Console.WriteLine(result);
        }
    }
}
