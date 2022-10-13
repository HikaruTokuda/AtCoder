using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtCoderKyoupro90
{
    // https://drken1215.hatenablog.com/entry/2021/10/10/195200
    class _006_SmallestSubsequence
    {
        public void Run()
        {
            var S = Console.ReadLine();
            int K = int.Parse(Console.ReadLine());
            var result = "";
            var nextS = S;
            var sortedS = String.Concat(nextS.OrderBy(ch => ch));       // 与えられた文字列を並び替え

            // K文字分連結したら終了
            while (K > 0)
            {
                foreach(var s in sortedS)                                   // 並び替えた五十音順の文字列を逐次処理
                {
                    if (!nextS.Contains(s)) continue;                       // 対象文字列に含まれない
                    if (nextS.Length - nextS.IndexOf(s) < K) continue;      // 対象文字が現れる地点より右側にK文字分ない
                    
                    // ここまでくれば条件を満たす
                    nextS = nextS.Substring(nextS.IndexOf(s) + 1);          // 対象文字が現れる地点より右側のみ抽出
                    result += s;                                            // 対象文字のみを連結
                    K--;                                                    // 結果文字数を1使用済みにする
                    break;                                                  // また五十音順を最初から調べる
                }

            }
            Console.WriteLine(result);
        }
        

    }
}
