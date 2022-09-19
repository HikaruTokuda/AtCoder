#include <iostream>
#include <vector>
#include <stack>
using namespace std;

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
    stack<int> st;
    st.emplace(s);  // sから探索する
    seen[s] = true;
    while (st.size() != 0) {   // 深さ優先探索
        int state = st.top();  // 現在の状態
        st.pop();
        for (auto next : G[state]) {
            if (!seen[next]) {  // 未探索の時のみ行う
                seen[next] = true;
                st.emplace(next);  //次の状態をqueueへ格納
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
