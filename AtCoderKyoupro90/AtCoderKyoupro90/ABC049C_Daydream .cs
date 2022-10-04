using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtCoderKyoupro90
{
    class ABC049C_Daydream
    {

        public void RunGreedy2()
        {
            var N = int.Parse(Console.ReadLine());
            List<(int, int)> StartsAndStops = new List<(int, int)>();
            for(int i = 0; i < N; i++)
            {
                var SS = Console.ReadLine().Split(' ');
                StartsAndStops.Add((int.Parse(SS[0]), int.Parse(SS[1])));
            }

            StartsAndStops.Sort((a, b) => a.Item2 - b.Item2);

            int preStopTime = -1;
            List<(int, int)> matchedTasks = new List<(int, int)>();
            foreach(var startAndStop in StartsAndStops.Select((v, i) => new { Value = v, Index = i}))
            {
                if(preStopTime <= startAndStop.Value.Item1)
                {
                    matchedTasks.Add(startAndStop.Value);
                    preStopTime = startAndStop.Value.Item2;
                }
            }

            Console.WriteLine("Matched tasks are following...");
            foreach(var matchedTask in matchedTasks)
            {
                Console.WriteLine(matchedTask);
            }


        }

        public void RunGreedy1()
        {
            List<int> kingakus = new List<int>();
            while(true)
            {
                var kingaku = int.Parse(Console.ReadLine());
                if(kingaku != 0)
                {
                    kingakus.Add(1000 - kingaku);
                }
                else
                {
                    break;
                }
            }

            List<int> koukas = new List<int>() { 500, 100, 50, 10, 5, 1 };
            List<int> results = new List<int>(new int[koukas.Count]);
            int currentKouka = 0;
            foreach(var kingaku in kingakus )
            {
                var tmp = kingaku;
                foreach(var kouka in koukas)
                {
                    while(tmp / kouka > 0)
                    {
                        tmp = tmp - kouka;
                        results[currentKouka]++;
                    }
                    currentKouka++;
                }
            }

            foreach(var result in results.Select((v, i) => new { Value = v, Index = i}))
            {
                Console.WriteLine($"{koukas[result.Index]}硬貨：{result.Value}枚");
            }

        }

        public void Run()
        {
            string T = "";
            string[] candidates = new string[] { "dream", "dreamer", "erase", "eraser" };
            string S = Console.ReadLine();
            bool isContinue = true;
            bool result = false;
            int position = S.Length;
            while(isContinue)
            {
                bool matched = false;
                foreach(var candidate in candidates)
                {
                    Console.WriteLine("--------------------------------------------------------------");
                    Console.WriteLine($"candidate: {candidate}");
                    var strNum = candidate.Length;
                    var currentTarget = S.Substring(position - strNum, strNum);
                    Console.WriteLine($"currentTarget: {currentTarget}");

                    if (currentTarget == candidate)
                    {
                        position -= strNum;
                        T += candidate;
                        matched = true;
                        Console.WriteLine($"★Matched! T: {T}");
                        break;
                    }                    
                }
                if (!matched) isContinue = false;
                if (position <= 0)
                {
                    isContinue = false;
                    result = true;
                }
            }

            if(result)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }

        public void RunOtoshidama()
        {
            int N = int.Parse(Console.ReadLine());
            int Y = int.Parse(Console.ReadLine());
            bool matched = false;

            for(int i = 0; i <= N; i++)
            {
                for(int j = 0; j <= N - i; j++)
                {
                    if( (10000 * i) + (5000 * j) + (1000 * (N - i - j)) == Y )
                    {
                        matched = true;
                        Console.WriteLine($"{i}, {j}, {N - i - j}");
                    }
                }
            }

            if (!matched) Console.WriteLine("-1 -1 -1");

        }

        public void RunKagamimochi()
        {
            /*////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /*   X 段重ねの鏡餅 (X≥1) とは、X 枚の円形の餅を縦に積み重ねたものであって、                                                    //
            /*   どの餅もその真下の餅より直径が小さい（一番下の餅を除く）もののことです。                                                   //
            /*   例えば、直径 10、8、6 センチメートルの餅をこの順に下から積み重ねると 3 段重ねの鏡餅になり、                                //
            /*   餅を一枚だけ置くと 1 段重ねの鏡餅になります。                                                                              //
            /*   ダックスフンドのルンルンは N 枚の円形の餅を持っていて、                                                                    //
            /*   そのうち i 枚目の餅の直径は di センチメートルです。                                                                        //
            /*   これらの餅のうち一部または全部を使って鏡餅を作るとき、最大で何段重ねの鏡餅を作ることができるでしょうか。                   //
            /*////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            int N = int.Parse(Console.ReadLine());
            List<int> ds = new List<int>();
            for(int i = 0; i < N; i++)
            {
                ds.Add(int.Parse(Console.ReadLine()));
            }

            var distinctedDs = ds.Distinct();
            Console.WriteLine(distinctedDs.Count());
        }

        public void CardGameForTwo()
        {
            int N = int.Parse(Console.ReadLine());
            List<int> cards = new List<int>();
            for(int i = 0; i < N; i++)
            {
                cards.Add(int.Parse(Console.ReadLine()));
            }

            cards.Sort();
            int Alice = 0;
            int Bob = 0;
            foreach(var card in cards.Select((v, i) => new { Value = v, Index = i}))
            {
                if(card.Index % 2 != 0)
                {
                    Alice += card.Value;
                }
                else
                {
                    Bob += card.Value;
                }
            }

            Console.WriteLine(Alice-Bob);
        }

    }
}
