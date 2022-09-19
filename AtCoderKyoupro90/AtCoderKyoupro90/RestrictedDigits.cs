using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtCoderKyoupro90
{
    class RestrictedDigits
    {
        public void Run()
        {

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
            if(n <= 2)
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


    }
}
