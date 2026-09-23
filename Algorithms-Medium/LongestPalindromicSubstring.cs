namespace Algorithms_Medium;

/// <summary>
/// 5. Longest Palindromic Substring
/// Given a string s, return the longest palindromic substring in s.
/// </summary>
public class LongestPalindromicSubstring
{
    /// <summary>
    /// Standart(Базовое решение). Решаем через перебор каждого возможного центра палиндрома, после сравниваем реузльтаты и выводим максимальный.
    /// </summary>
    /// <param name="s">"abb"</param>
    /// <returns>bb</returns>
    public string LongestPalindrome(string s)
    {
        if (string.IsNullOrEmpty(s))
            return "";

        int startPointer = 0;
        int endPointer = 0;

        for (int i = 0; i < s.Length; i++)
        {
            int len1 = ExpandCenter(s, i, i);
            int len2 = ExpandCenter(s, i, i + 1);

            int len = Math.Max(len1, len2);

            if (len > endPointer - startPointer + 1)
            {
                startPointer = i - (len - 1) / 2;
                endPointer = i + len / 2;
            }
        }

        return s.Substring(startPointer, endPointer - startPointer + 1);
    }
    
    /// <summary>
    /// BestSpeed(Лучшее по скорости - Жёлтый). Чё то на быстром и непонятном. // TODO: Разобраться как работает этот алгоритм перебора.
    /// </summary>
    /// <param name="s">"abb"</param>
    /// <returns>bb</returns>
    public string LongestPalindromeBestSpeed(string s) {
        if (s.Length == 0) return "";
        int max_start = 0;
        int max_len = 0;
        int l, r;
        int c = 0;

        while (c + (max_len >> 1) < s.Length) {
            l = c - 1;
            r = c;

            while (r < s.Length && s[r] == s[c]) r++;
            
            c = r;

            while (l >= 0 && r < s.Length && s[l] == s[r]) {
                l--;
                r++;
            }
            
            r = r - l - 1;
            if (r > max_len) {
                max_start = l + 1;
                max_len = r;
            }
        }

        return s.Substring(max_start, max_len);
    }
    
    private int ExpandCenter(string s, int left, int right)
    {
        while (left >= 0 &&
               right < s.Length &&
               s[left] == s[right])
        {
            left--;
            right++;
        }

        return right - left - 1;
    }
}