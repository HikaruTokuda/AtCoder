using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.Intrinsics;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace AtCoderKyoupro90
{
    class ABC085C_Otoshidama
    {
        public void Run()
        {
            // 入力値を取得
            var input = Console.ReadLine().Split(" ");
            int N = int.Parse(input[0]);
            int Y = int.Parse(input[1]);

            // 紙幣数の初期化
            int x = -1;
            int y = -1;
            int z = -1;
            int nowSum = 0;

            // 紙幣の組合せを検証
            for (int i = 0; i <= N; i++)
            {
                for (int j = 0; j <= N - i; j++)
                {
                    int k = N - (i + j);
                    nowSum = 10000 * i + 5000 * j + 1000 * k;
                    if (Y == nowSum)
                    {
                        x = i;
                        y = j;
                        z = k;
                    }
                    if (x != -1) break;
                }

                if (x != -1) break;
            }
            // 紙幣の組合せを出力 (あり得ない場合、-1 -1 -1を出力)
            Console.WriteLine($"{x} {y} {z}");
        }
    }
}