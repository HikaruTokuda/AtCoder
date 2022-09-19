using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtCoderKyoupro90
{
    class EncyclopediaOfParentheses
    {
        public void Run()
        {
            var N = int.Parse(Console.ReadLine());
            if (N % 2 != 0) return;

            for (int i = 0; i < (int)Math.Pow(2, N); i++)
            {
                var currentTarget = Convert.ToString(i, 2).PadLeft(N, '0');

                // 1文字目が「)」
                if (currentTarget.Substring(0, 1) == "1") continue;

                // 「(」と「)」の出現回数が違う
                if (currentTarget.Count(f => f == '0') != currentTarget.Count(f => f == '1')) continue;

                // 末尾が「(」
                if (currentTarget.Substring(N - 1, 1) == "0") continue;

                // ある時点で「)」が「(」を超えてはいけない
                bool isContinue = true;
                int zeroNum = 0;
                int oneNum = 0;
                foreach (var ch in currentTarget)
                {
                    if (ch == '0') zeroNum++;
                    else oneNum++;

                    if(oneNum > zeroNum)
                    {
                        isContinue = false;
                        break;
                    }
                }
                if (!isContinue) continue;

                currentTarget = currentTarget.Replace('0', '(');
                currentTarget = currentTarget.Replace('1', ')');
                Console.WriteLine(currentTarget);

            }
        }

        public void Run_kousiki()
        {
            int N = int.Parse(Console.ReadLine());
            // 2進数を左にSビット論理シフトすると、2^S倍することに相当
            // http://kccn.konan-u.ac.jp/information/cs/cyber03/cy3_shc.htm
            for (int i = 0; i < (1 << N); i++)
            {
                string candidate = "";
                for(int j = N-1; j >= 0; j--)
                {
                    // (i & (1 << j)) == 0 というのは、i の j ビット目（2^j の位）が 0 であるための条件
                    // 0を「(」、1を「)」としている
                    if ((i & (1 << j)) == 0)
                    {
                        candidate += "(";
                    }
                    else
                    {
                        candidate += ")";
                    }
                }
                bool I = hantei(candidate);
                if (I) Console.WriteLine(candidate);                
            }
        }

        bool hantei(string S)
        {
            int dep = 0;
            for(int i = 0; i < S.Length; i++)
            {
                if (S.Substring(i, 1) == "(") dep++;
                if (S.Substring(i, 1) == ")") dep--;
                // 「)」が「(」より多くなったとき
                if (dep < 0) return false;
            }
            // 「(」と「)」が同数なら真
            return dep == 0;
        }

        public void RunDFS()
        {
            var VE = Console.ReadLine().Split(' ');
            var V = int.Parse(VE[0]);
            var E = int.Parse(VE[1]);
            var st = Console.ReadLine().Split(' ');
            var s = int.Parse(st[0]);
            var t = int.Parse(st[1]);
            List<VertexModel> vartexes = new List<VertexModel>();

            for (int i = 0; i < E; i++)
            {
                var startend = Console.ReadLine().Split(' ');
                var start = int.Parse(startend[0]);
                var end = int.Parse(startend[1]);

                bool added = false;
                foreach (var vertex in vartexes)
                {
                    if (vertex.vertex == start)
                    {
                        // 既存の頂点
                        vertex.destinations.Add(end);
                        added = true;
                    }
                }
                if (!added)
                {
                    // 新規の頂点
                    vartexes.Add(new VertexModel
                    {
                        vertex = start,
                        destinations = new List<int>() { end }
                    });
                }

            }
		
		    foreach(var vartex in vartexes)
		    {
                Console.WriteLine($"vartex: {vartex.vertex}");
                Console.WriteLine("destinations:");
                foreach (var dist in vartex.destinations)
                {
                    Console.WriteLine(dist);
                }
		    }

            var startVertex = vartexes.Where( vr => vr.vertex == s ).ToList()[0];            

	    }

        int GetNextVertex(List<VertexModel> vartexes, int start)
        {
            var nexts = vartexes.Where(vr => vr.vertex == start).ToList();
            return nexts.Count;
        }
    }

    public class VertexModel
    {
        public int vertex;
        public List<int> destinations = new List<int>();
    }
}
