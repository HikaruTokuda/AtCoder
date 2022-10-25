using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtCoderKyoupro90
{
    class _007_CPClasses
    {
        public void Run()
        {
            // 入力
            int N = int.Parse(Console.ReadLine());
            List<int> A = Console.ReadLine().Split(" ").ToList().Select(c => int.Parse(c)).ToList();
            int Q = int.Parse(Console.ReadLine());
            List<int> B = new List<int>();
            for (int i = 0; i < Q; i++)
            {
                B.Add(int.Parse(Console.ReadLine()));
            }

            // 小さい順に並び替え
            A.Sort();
            //B.Sort();

            foreach(var b in B)
            {
                var upperOneRank = A.Where(a => a > b).ToList();
                var lowerOneRank = A.Where(a => a < b).ToList();
                if(upperOneRank.Count == 0) 
                {
                    Console.WriteLine(Math.Abs(lowerOneRank.First() - b));
                    continue;
                }
                if(lowerOneRank.Count == 0)
                {
                    Console.WriteLine(Math.Abs(upperOneRank.First() - b));
                    continue;
                }
                if (Math.Abs(upperOneRank.First() - b) > Math.Abs(lowerOneRank.First() - b))
                {
                    Console.WriteLine(Math.Abs(lowerOneRank.First() - b));
                }
                else
                {
                    Console.WriteLine(Math.Abs(upperOneRank.First() - b));
                }
            }
        }

        public void Run_origin()
        {
            // 入力
            int N = int.Parse(Console.ReadLine());
            List<int> A = Console.ReadLine().Split(" ").ToList().Select(c => int.Parse(c)).ToList();
            int Q = int.Parse(Console.ReadLine());
            List<int> B = new List<int>();
            for(int i = 0; i < Q; i++)
            {
                B.Add(int.Parse(Console.ReadLine()));
            }


            // 小さい順に並び替え
            A.Sort();

            // 最小値を探す
            int sub = int.MaxValue;
            foreach(var b in B)
            {
                foreach(var a in A)
                {
                    var currentSub = Math.Abs(a - b);
                    if (currentSub < sub )
                    {
                        sub = currentSub;
                    }
                }
                Console.WriteLine(sub);
                sub = int.MaxValue;
            }           

        }
    }
}
