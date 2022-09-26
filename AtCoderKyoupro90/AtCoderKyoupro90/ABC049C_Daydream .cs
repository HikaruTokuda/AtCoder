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

    }
}
