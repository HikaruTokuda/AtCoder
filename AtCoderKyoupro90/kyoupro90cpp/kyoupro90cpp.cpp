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
    int N;
    cin >> N;
    vector<int> X(N), L(N);
    for (int i = 0; i < N; i++) {
        cin >> X.at(i) >> L.at(i);
    }
    vector<pair<int, int>> p(N);
    for (int i = 0; i < N; i++) {
        p[i].first = X[i] + L[i]; // 終端を先に入れておく
        p[i].second = X[i] - L[i];
    }
    sort(p.begin(), p.end()); // 終端を優先にソート
    int ans = 1;
    int t = p[0].first; // t:=現在までに選択した区間の中で一番後ろの点
    for (int i = 1; i < N; i++) {
        if (t <= p[i].second) {
            ans++;
            t = p[i].first;
        }
    }
    cout << ans << endl;
    return 0;
}
