using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtCoderKyoupro90
{
    class _010_ScoreSumQueries
    {
        public void Run()
        {
            int N = int.Parse(Console.ReadLine());
            // 累積和用の配列(在籍人数+初期値) 2クラス分作成
            int[] sum1 = new int[N + 1];
            int[] sum2 = new int[N + 1];

            // 質問Qの前処理(累積和の計算)
            for (int i = 1; i <= N; i++)
            {
                string[] data1 = Console.ReadLine().Split(" ");
                int P = int.Parse(data1[1]);
                if ("1".Equals(data1[0]))
                {
                    sum1[i] = sum1[i - 1] + P;
                    sum2[i] = sum2[i - 1];
                }
                else
                {
                    sum1[i] = sum1[i - 1];
                    sum2[i] = sum2[i - 1] + P;
                }
            }

            // 質問Qの計算実行
            int Q = int.Parse(Console.ReadLine());
            List<string> results = new List<string>();

            for (int i = 1; i <= Q; i++)
            {
                string[] data2 = Console.ReadLine().Split(" ");
                int start = int.Parse(data2[0]);
                int end = int.Parse(data2[1]);

                results.Add((sum1[end] - sum1[start - 1]).ToString() + " " + (sum2[end] - sum2[start - 1]).ToString());
            
            }

            // 質問Qの計算結果リスト出力
            foreach(var res in results)
            {
                Console.WriteLine(res);
            }
        }
    }
}
