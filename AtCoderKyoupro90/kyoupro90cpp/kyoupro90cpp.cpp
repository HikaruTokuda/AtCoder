#include <iostream>
#include <stdio.h>
#include <vector>
using namespace std;

long long N;
string S;
vector<pair<char, long long>> vec;

int main() {
	cin >> N >> S;

	// ランレングス圧縮
	long long cnt = 0;
	for (int i = 0; i < S.size(); i++) {
		cnt++;
		// 右隣の文字が違ったら追加
		if (i == (int)S.size() - 1 || S[i] != S[i + 1]) {
			vec.push_back(make_pair(S[i], cnt));
			cnt = 0;
		}
	}

	// oだけ or xだけは１つのpair内の組み合わせの個数になる
	long long ret = 0;
	for (int i = 0; i < vec.size(); i++) {
		ret += 1LL * vec[i].second * (vec[i].second + 1LL) / 2LL;
	}
	// 全pairのpair内組み合わせの個数が出きったら、全体から引く
	cout << N * (N + 1) / 2LL - ret << endl;
	return 0;
}