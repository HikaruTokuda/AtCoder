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
    }
}
