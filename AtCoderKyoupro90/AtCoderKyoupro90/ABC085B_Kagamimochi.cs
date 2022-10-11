using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtCoderKyoupro90
{
    class Kagamimochi
    {
        public void Run()
        {
            int N = int.Parse(Console.ReadLine());
            List<int> mochis = new();

            for(int i = 0; i < N; i++)
            {
                int size= int.Parse(Console.ReadLine());
                if (!mochis.Contains(size))
                {
                    mochis.Add(size);
                }
            }

            Console.WriteLine(mochis.Count);
        }
    }
}
