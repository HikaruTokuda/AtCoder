#include <iostream>
#include <vector>
#include <stack>
#include <queue>
using namespace std;

// 入力
int N;
int A[1 << 18], B[1 << 18];

// グラフ
const int INF = (1 << 29);
vector<int> G[1 << 18];
int dist[1 << 18];

void getdist(int start) {
	// 幅優先探索（BFS）により、最短距離を計算
	for (int i = 1; i <= N; i++) dist[i] = INF;

	queue<int> Q;
	Q.push(start);
	dist[start] = 0;

	while (!Q.empty()) {
		int pos = Q.front(); Q.pop();
		for (int to : G[pos]) {
			if (dist[to] == INF) {
				dist[to] = dist[pos] + 1;
				Q.push(to);
			}
		}
	}
}

int main()
{
    int V, E;
    cin >> V >> E;
    int s, t;
    cin >> s >> t;
    vector<vector<int>> G(V);
    for (int i = 0; i < E; i++) {
        int a, b;
        cin >> a >> b;
        G[a].push_back({ b });
        // G[b].push_back({a});
    }
    vector<bool> seen(V, false);  // 既に見たことがある頂点か記録する
    queue<int> que;
    que.emplace(s);  // sから探索する
    seen[s] = true;
    while (que.size() != 0) {     // 幅優先探索
        int state = que.front();  // 現在の状態
        que.pop();
        for (auto next : G[state]) {
            if (!seen[next]) {  // 未探索の時のみ行う
                seen[next] = true;
                que.emplace(next);  //次の状態をqueueへ格納
            }
        }
    }
    if (seen[t]) {
        cout << "yes" << endl;
    }
    else {
        cout << "no" << endl;
    }
    return 0;
}
