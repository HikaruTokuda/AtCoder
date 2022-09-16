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
    }
}
