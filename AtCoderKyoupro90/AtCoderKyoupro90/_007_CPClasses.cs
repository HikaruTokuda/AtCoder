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
                var upperOneRank = A.Where(a => a > b).ToList().First();
                if (A.IndexOf(upperOneRank) == 0)
                {
                    Console.WriteLine(Math.Abs(upperOneRank - b));
                    continue;
                }

                var lowerOneRank = A[A.IndexOf(upperOneRank) - 1];
                if(A.IndexOf(lowerOneRank) + 1 == A.Count) 
                {
                    Console.WriteLine(Math.Abs(lowerOneRank - b));
                    continue;
                }

                if (Math.Abs(upperOneRank - b) > Math.Abs(lowerOneRank - b))
                {
                    Console.WriteLine(Math.Abs(lowerOneRank - b));
                }
                else
                {
                    Console.WriteLine(Math.Abs(upperOneRank - b));
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
