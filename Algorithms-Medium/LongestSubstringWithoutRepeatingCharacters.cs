namespace Algorithms_Medium;

/// <summary>
/// 3. Longest Substring Without Repeating Characters
/// Given a string s, find the length of the longest substring without duplicate characters.
/// </summary>
public class LongestSubstringWithoutRepeatingCharacters
{
    /// <summary>
    /// Standart(Базовое решение). Решаем через Queue, создаём своеобразное окно поверх массива
    /// что бы сохранять только уникальные значения, сравниваем текущее колличество символов с последним максимальным.
    /// Возможно можно решить через Dictionary (char, int)  uniqueWord сохраняем символ и его позицию в массиве,
    /// вычитаем от i - uniqueWord[i] и получаем длинну уникальных символов.
    /// </summary>
    /// <param name="s">"pwwkew"</param>
    /// <returns>3</returns>
    public int LengthOfLongestSubstring(string s)
    {
        int result = 0;
        Queue<char> uniqueWord = new Queue<char>();

        for (int i = 0; i < s.Length; i++)
        {
            if (!uniqueWord.Contains(s[i]))
            {
                uniqueWord.Enqueue(s[i]);
            }
            else
            {
                if (uniqueWord.Count > result)
                    result = uniqueWord.Count;

                while (uniqueWord.Contains(s[i]))
                    uniqueWord.Dequeue();
                
                uniqueWord.Enqueue(s[i]);
            }
        }
        
        if(uniqueWord.Count > result)
            result = uniqueWord.Count;

        return result;
    }
    
    /// <summary>
    /// BestSpeed(Лучшее по скорости - Жёлтый). Алгоритм реализует скользящее окно (sliding window) и хранит для каждого символа его последнюю позицию появления.
    /// Таким образом, когда встречается повтор, окно сдвигается вправо, чтобы исключить повторяющийся символ.
    /// </summary>
    /// <param name="s">"pwwkew"</param>
    /// <returns>3</returns>
    public int LengthOfLongestSubstringBestSpeed(string s)
    {
        unsafe
        {
            int length = s.Length;

            if (length < 2)
                return length;
            
            int* lastSeen = stackalloc int[128];

            new System.Span<ushort>(
                lastSeen,
                128
            ).Clear();

            int windowStart = 0;
            int maxLength = 0;

            fixed (char* chars = s)
            {
                for (int i = 0; i < length; i++)
                {
                    int character = chars[i];
                    int previousEnd = lastSeen[character];
                    
                    if (previousEnd > windowStart)
                        windowStart = previousEnd;

                    lastSeen[character] = i + 1;

                    int currentLength =
                        i - windowStart + 1;

                    if (currentLength > maxLength)
                        maxLength = currentLength;
                }
            }

            return maxLength;
        }
    }
}