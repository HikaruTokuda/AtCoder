using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtCoderKyoupro90
{
    class _014_WeUsedtoSingaSongTogether
    {
        public void Run()
        {
            int N = int.Parse(Console.ReadLine());
            string[] inputA = Console.ReadLine().Split(" ");
            string[] inputB = Console.ReadLine().Split(" ");
            int[] A = new int[N];
            int[] B = new int[N];
            long result = 0;

            for(int i = 0; i < N; i++)
            {
                A[i] = int.Parse(inputA[i]);
                B[i] = int.Parse(inputB[i]);
            }
            Array.Sort(A);
            Array.Sort(B);

            // 不便さを演算
            for(int i = 0; i < N; i++)
            {
                result += Math.Abs(A[i] - B[i]);
            }
            Console.WriteLine(result);
        }
    }
}
