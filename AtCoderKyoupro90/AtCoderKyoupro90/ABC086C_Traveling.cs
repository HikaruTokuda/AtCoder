using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtCoderKyoupro90
{
    class Traveling
    {
        public void Run()
        {
            string input = Console.ReadLine();
            int N = int.Parse(input);
            int[][] goals = new int[N][];
            int[] times = new int[N];

            for (int i = 0; i < N; i++)
            {
                goals[i] = new int[2];
                input = Console.ReadLine();

                // 移動に必要な時間、移動先の点を取得
                times[i] = int.Parse(input.Split(" ")[0]);
                goals[i][0] = int.Parse(input.Split(" ")[1]);
                goals[i][1] = int.Parse(input.Split(" ")[2]);

                // 移動開始点は最初は0,0、それ以外は前の点
                // 移動に必要な時間も前の点までの分を引く
                int[] start = new int[2];
                if (i == 0)
                {
                    start[0] = 0; start[1] = 0;
                }
                else
                {
                    start[0] = goals[i - 1][0]; start[1] = goals[i - 1][1];
                    times[i] -= times[i - 1];
                }

                // 毎回判定、一回でもアウトなら終了
                if (!Judge(start, goals[i], times[i]))
                {
                    Console.WriteLine("No");
                    return;
                }
            }

            Console.WriteLine("Yes");
        }

        bool Judge(int[] start, int[] goal, int time)
        {
            // 距離はx軸の差とy軸の差の和（1,2 => 4,5 なら3+3で6）
            int dist = Math.Abs(goal[0] - start[0]) + Math.Abs(goal[1] - start[1]);

            // 移動に使える時間が距離以上であること、距離と時間の差が偶数ならOK。奇数だと隣にしか行けない
            if (time >= dist && (dist - time) % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
