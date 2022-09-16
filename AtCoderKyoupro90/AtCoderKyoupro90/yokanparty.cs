using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtCoderKyoupro90
{
    /// <summary>
    /// Yokan party
    /// written by komori
    /// </summary>
    class yokanparty
    {
        public void Run()
        {
            string input = Console.ReadLine();
            int N = int.Parse(input.Split(" ")[0]);
            int L = int.Parse(input.Split(" ")[1]);
            input = Console.ReadLine();
            int K = int.Parse(input);
            input = Console.ReadLine();
            int[] A = new int[100000];
            for (int i = 0; i < input.Split(" ").Length; i++)
            {
                A[i] = int.Parse(input.Split(" ")[i]);
            }

            Console.WriteLine("");

            // 自分で作ったほう
            int score = CalcScore(N, L, K, A);
            Console.WriteLine("CalcScore result: " + score);
            Console.WriteLine("");
            // GitHubの回答
            score = CalcScore2(N, L, K, A);
            Console.WriteLine("GitHub result: " + score);
            Console.ReadLine();

        }

        static int CalcScore(int N, int L, int K, int[] A)
        {
            int ret = L;

            // 全部切る  
            int[] pieces = new int[A.Length + 1];

            for (int i = 0; i < A.Length; i++)
            {
                if (i == 0)
                {
                    // 最初は切れ目までの長さ
                    pieces[i] = A[i];
                }
                else
                {
                    // それ以外は切れ目までの長さから前の切れ目までの長さを引いた分
                    pieces[i] = A[i] - A[i - 1];
                }

                if (i == A.Length - 1)
                {
                    // 最後の切れ目のときは羊羹の長さから最後の切れ目までの長さを引いた分
                    pieces[i + 1] = L - A[i];
                }
            }

            // 足していって(羊羹の長さ/ピースの数)を超えたらその手前とどっちが近いか
            int lengthNow = 0;
            for (int i = 0; i < pieces.Length; i++)
            {
                lengthNow = lengthNow + pieces[i];

                // (羊羹の長さ/ピースの数)を超えたら判定
                if (lengthNow >= L / (K + 1))
                {
                    // 超えないほうがいいとき
                    if ((lengthNow - (L / (K + 1))) >= ((L / (K + 1)) - (lengthNow - pieces[i])))
                    {
                        int score = lengthNow - pieces[i];
                        Console.WriteLine("score: {0}, i: {1}", score, i);

                        if (score < ret)
                        {
                            ret = score;
                        }
                        lengthNow = pieces[i];
                    }
                    else if ((lengthNow - (L / (K + 1))) < ((L / (K + 1)) - (lengthNow - pieces[i])))
                    {
                        int score = lengthNow;
                        Console.WriteLine("score: {0}, i: {1}", score, i + 1);
                        if (score < ret)
                        {
                            ret = score;
                        }
                        lengthNow = 0;
                    }
                }

                // 最後のピース
                if (i == pieces.Length - 1 && lengthNow != 0)
                {
                    int score = lengthNow;
                    Console.WriteLine("score: {0}", score);
                    if (score < ret)
                    {
                        ret = score;
                    }
                }
            }

            return ret;
        }

        static int CalcScore2(int N, int L, int K, int[] A)
        {
            // Step #2. 答えで二分探索（めぐる式二分探索法）
            // https://qiita.com/drken/items/97e37dd6143e33a64c8c
            double left = -1;
            double right = L + 1;
            while (right - left > 1)
            {
                double mid = left + (right - left) / 2;
                if (solve(mid, N, L, K, A) == false)
                {
                    right = mid;
                }
                else
                {
                    left = mid;
                }
            }
            //cout << left << endl;

            double ret = Math.Floor(right);

            return (int)ret;
        }

        static bool solve(double M, int N, int L, int K, int[] A)
        {
            double cnt = 0, pre = 0;

            // 切れ目の数だけループ
            for (int i = 0; i < N; i++)
            {
                // i番目の切れ目で切った時の長さがM以上、かつ後ろの長さがM以上
                if (A[i] - pre >= M && L - A[i] >= M)
                {
                    cnt += 1;
                    pre = A[i];
                }
            }
            // M以上の長さでK個に分割できればtrue、できなければfalse
            if (cnt >= K) return true;
            return false;
        }
    }
}
