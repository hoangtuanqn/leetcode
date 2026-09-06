# 115. Distinct Subsequences — Full Guide

## Bài hỏi gì?

Cho `s = "rabbbit"`, `t = "rabbit"`. Hỏi có bao nhiêu cách **chọn ký tự từ s** (giữ nguyên thứ tự) để ghép thành t?

```
r a b b b i t
r a b b _ i t  → cách 1
r a b _ b i t  → cách 2
r a _ b b i t  → cách 3
```

Đáp án = 3.

---

## Định nghĩa dp

```
dp[i][j] = số cách tạo t[0..j-1] từ s[0..i-1]
```

Nói thẳng hơn: **dùng i ký tự đầu của s, tạo j ký tự đầu của t được bao nhiêu cách.**

**Tại sao `s[i-1]` không phải `s[i]`?** Vì bảng dp có hàng 0 (biểu diễn chuỗi rỗng), nên i đang "đếm", còn index thực trong mảng là i-1.

```
i=1 → đang xét s[0]
i=2 → đang xét s[1]
i=3 → đang xét s[2]  ← s[i-1]
```

---

## Base case

```
dp[i][0] = 1   → tạo chuỗi rỗng: luôn có 1 cách (không chọn gì)
dp[0][j] = 0   → s rỗng mà t khác rỗng: không thể
```

---

## Công thức — tại mỗi ô dp[i][j]

Đứng ở `s[i-1]`, ta có 2 lựa chọn:

**Không dùng s[i-1]:**
```
→ bỏ qua s[i-1], vẫn cần tạo t[0..j-1] từ s[0..i-2]
→ dp[i-1][j]
```

**Dùng s[i-1]** (chỉ khi `s[i-1] == t[j-1]`):
```
→ s[i-1] match t[j-1] → cả hai biến mất
→ còn lại cần tạo t[0..j-2] từ s[0..i-2]
→ dp[i-1][j-1]
```

**Tại sao cộng lại?** Vì hai nhánh là hai nhóm cách chọn **hoàn toàn khác nhau** — nhóm có dùng `s[i-1]` và nhóm không dùng `s[i-1]`. Không trùng nhau → cộng lại = tổng.

```
dp[i][j] = dp[i-1][j]
          + dp[i-1][j-1]  (chỉ khi s[i-1] == t[j-1])
```

---

## Trace tay — s = "aa", t = "a"

```
        j=0    j=1
        ""     "a"
i=0 ""   1      0
i=1 "a"  1      1
i=2 "aa" 1      2   ← đáp án
```

**dp[1][1]** — xét `s[0]='a'`, `t[0]='a'`:
```
Không dùng: dp[0][1] = 0
Dùng:       dp[0][0] = 1
→ dp[1][1]  = 0 + 1 = 1
```

**dp[2][1]** — xét `s[1]='a'`, `t[0]='a'`:
```
Không dùng: dp[1][1] = 1  → cách: [a] _
Dùng:       dp[1][0] = 1  → cách:  _ [a]
→ dp[2][1]  = 1 + 1 = 2 ✓
```

---

## Tại sao cần cap INT_MAX?

Test case lớn khiến dp cộng dồn vượt giới hạn `long long` → overflow.

Nhưng LeetCode **đảm bảo đáp án cuối fit trong `int`**, nên:

```
dp[n][m] <= INT_MAX

Mà dp chỉ tăng → dp[i][j] <= dp[n][m] <= INT_MAX

→ Nếu dp[i][j] > INT_MAX thì dp[n][m] cũng > INT_MAX
→ Mâu thuẫn với đề bài
→ Không thể xảy ra
```

Vậy cap ở `INT_MAX` **không làm sai đáp án**, chỉ ngăn overflow.

---

## Code

```cpp
int numDistinct(string s, string t) {
    int n = s.size(), m = t.size();
    vector<vector<ll>> dp(n + 1, vector<ll>(m + 1, 0));

    // Base case: tạo chuỗi rỗng luôn có 1 cách
    for (int i = 0; i <= n; i++)
        dp[i][0] = 1;

    for (int i = 1; i <= n; i++) {
        for (int j = 1; j <= m; j++) {
            // Không dùng s[i-1]
            dp[i][j] = dp[i-1][j];

            // Dùng s[i-1] match t[j-1]
            if (s[i-1] == t[j-1])
                dp[i][j] += dp[i-1][j-1];

            // Cap để tránh overflow (đáp án đảm bảo fit trong int)
            dp[i][j] = min(dp[i][j], (ll)INT_MAX);
        }
    }

    return (int)dp[n][m];
}
```

---

## Độ phức tạp

```
Time:  O(n × m) — fill từng ô một lần, mỗi ô O(1)
Space: O(n × m) — bảng dp
```