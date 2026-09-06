    #pragma GCC optimize("O2")
    #pragma GCC optimize("unroll-loops")
    #pragma GCC target("avx2")
    #include <bits/stdc++.h>
    using namespace std;

    // Types
    #define ll long long
    #define ull unsigned long long
    #define ld long double
    #define pii pair<int, int>
    #define pll pair<ll, ll>

    // Vectors
    #define vi vector<int>
    #define vl vector<ll>
    #define vii vector<pii>
    #define vb vector<bool>

    // Loops
    #define FOR(i, a, b) for (int i = (a); i < (b); ++i)
    #define RFOR(i, a, b) for (int i = (a); i >= (b); --i)
    #define each(x, v) for (auto& x : v)

    // Shortcuts
    #define pb push_back
    #define mp make_pair
    #define fi first
    #define se second
    #define sz(x) (int)(x).size()
    #define all(x) (x).begin(), (x).end()
    #define rall(x) (x).rbegin(), (x).rend()

    // Utils
    #define YES cout << "YES\n"
    #define NO cout << "NO\n"
    #define dbg(x) cerr << #x << " = " << x << "\n"

    // Constants
    const int INF = 1e9 + 7;
    const ll LINF = 1e18;
    const int MOD = 1e9 + 7;

    // ====== SOLUTION
    int numDistinct(string s, string t) {
        int n = s.size(), m = t.size();
        vector<vector<ll>> dp(n + 1, vector<ll>(m + 1, 0));
        for (int i = 0; i <= n; ++i)
            dp[i][0] = 1;

        for (int i = 1; i <= n; ++i) {
            for (int j = 1; j <= m; ++j) {
                dp[i][j] = dp[i - 1][j];
                if (s[i - 1] == t[j - 1]) {
                    dp[i][j] += dp[i - 1][j - 1];
                }
                dp[i][j] = min(dp[i][j], (ll)INT_MAX);
            }
        }
        return (int)dp[n][m];
    }
    int main() {
        ios::sync_with_stdio(0);
        cin.tie(0);
        cout.tie(0);
        string s = "rabbbit";
        string t = "rabbit";

        cout << numDistinct(s, t);

        return 0;
    }
