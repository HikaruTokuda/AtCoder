#define DFS
#define BFS

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AtCoderKyoupro90
{
    public class VertexModel
    {
        public int vertex;
        public List<int> destinations = new List<int>();
    }

    class LongestCircularRoad
    {
        List<VertexModel> vartexes = new List<VertexModel>();       // 頂点の情報
        List<List<int>> pathList = new List<List<int>>();           // ある頂点からたどり着けるグラフの終端
        bool isEnd = false;                                         // グラフの終端までたどり着いたかどうか
        int V, E;
#if (BFS || DFS)
        int s, t;
#else
        int s;
#endif


        public void RunKinoTyokkei()
        {
            // 入力値解析
            var VE = Console.ReadLine().Split(' ');
            V = int.Parse(VE[0]);
            E = int.Parse(VE[1]);


        }


#if DFS
        public void RunDFS()
        {
            // 入力値解析
            var VE = Console.ReadLine().Split(' ');
            V = int.Parse(VE[0]);
            E = int.Parse(VE[1]);
            var st = Console.ReadLine().Split(' ');
            s = int.Parse(st[0]);
            t = int.Parse(st[1]);

            // 入力値から頂点情報を作成
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

            foreach (var vartex in vartexes)
            {
                Console.WriteLine($"vartex: {vartex.vertex}");
                Console.WriteLine("destinations:");
                foreach (var dist in vartex.destinations)
                {
                    Console.WriteLine(dist);
                }
            }

            // 指定した頂点からの経路情報を作成
            List<int> pathes = new List<int>();
            CreatePathModel(s, pathes);

            // 指定したゴールが経路一覧の中に存在していればOK
            foreach (var path in pathList)
            {
                if (path.Contains(t))
                {
                    Console.WriteLine($"yes");
                    break;
                }
            }

        }
#endif

        /*//////////////////////////////////////////////
        //              経路情報の作成                //
        // パラメータ                                 //
        // s: 現在のスタート位置                      //
        // firstStart: 指定されたスタート位置         // 
        // currentPath: 現在の経路情報                //
        /// //////////////////////////////////////////*/
        void CreatePathModel(int currentStart, List<int> pathes/*, int firstStart, PathModel currentPath*/)
        {
            // 現在のスタート位置をスタート点にもつ頂点情報を抽出
            var startVertexes = vartexes.Where(vr => vr.vertex == currentStart).ToList();

            if (startVertexes.Count == 0)
            {
                //// 現在のスタート位置をスタート点に持つ頂点がない(その頂点から経路は伸びていない)
                List<int> forAdd = new List<int>(pathes);
                pathList.Add(forAdd);
                isEnd = true;
                return;
            }
            
            var startVertex = startVertexes[0];
            if (startVertex.destinations.Count == 0)
            {
            }

            // 現在のスタート位置をスタート点にもつ頂点から伸びている行き先ごとに
            foreach (var path in startVertex.destinations)
            {
                if(isEnd == false)
                {
                    // 道中であればpathesに追加
                    pathes.Add(path);
                }
                else
                {
                    // 終端であれば
                    pathes.Clear();
                    if(currentStart != s)
                    {
                        // 現在のスタート位置が、指定されたスタート位置でない場合、道中なのでその点も追加する
                        pathes.Add(currentStart);
                    }
                    pathes.Add(path);

                    isEnd = false;
                }
                // スタート位置を次の点にして再帰呼び出し
                CreatePathModel(path, pathes);
            }
        }

#if BFS
    public void RunBFS()
        {
            // 入力値解析
            var VE = Console.ReadLine().Split(' ');
            V = int.Parse(VE[0]);
            E = int.Parse(VE[1]);
            var st = Console.ReadLine().Split(' ');
            s = int.Parse(st[0]);
            t = int.Parse(st[1]);

            // index: 頂点
            // 子List：その頂点からの行き先
            List<List<int>> points = new List<List<int>>();

            // 入力値から頂点情報を作成
            for (int i = 0; i < E; i++)
            {
                var startend = Console.ReadLine().Split(' ');
                var start = int.Parse(startend[0]);
                var end = int.Parse(startend[1]);

                if(start > points.Count - 1)
                {
                    points.Add(new List<int>() { end });
                }
                else
                {
                    points[start].Add(end);
                }
            }

            // 既に見たことがある頂点か記録
            List<bool> seen = new List<bool>(new bool[V]);

            Queue<int> que = new Queue<int>();
            que.Enqueue(s);                         // sから探索する
            seen[s] = true;                         // sは確認済み

            // Queueの要素がなくなるまで
            while(que.Count != 0)
            {
                // 現在確認している頂点
                int state = que.Dequeue();   
                // 現在確認している頂点から辺が伸びていない場合
                if (state >= points.Count) break;
                // 現在確認している頂点から繋がっている頂点
                foreach(var point in points[state])
                {
                    // 既に確認済みの頂点か
                    if(!seen[point])
                    {
                        // 未確認の頂点の場合、その頂点を確認済みにし、Queueに追加
                        seen[point] = true;
                        que.Enqueue(point);
                    }
                }
            }

            if (seen[t]) Console.WriteLine("yes");
            else Console.WriteLine("no");
        }
#endif
    }
}