using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtCoderKyoupro90
{
    class _084_ThereAreTwoTypesOfCharacters
    {
        public void Run()
        {
                int N = int.Parse(Console.ReadLine());
                string S = Console.ReadLine();
                List<(int, int)> res = new List<(int, int)>();

                for (int l = 0; l < N; l++)
                {
                    for (int r = l + 1; r < N; r++)
                    {
                        var s = S.Substring(l, r - l + 1);
                        if (s.Contains("o") && s.Contains("x"))
                        {
                            res.Add((l, r));
                        }
                    }
                }

                foreach (var r in res)
                {
                    Console.WriteLine($"l = {r.Item1}__ r = {r.Item2}__ {S.Substring(r.Item1, r.Item2 - r.Item1 + 1)}");
                }

                Console.WriteLine(res.Count);

        }
    }
}
