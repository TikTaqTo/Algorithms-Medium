namespace Algorithms_Medium;

/// <summary>
/// 11. Container With Most Water
/// You are given an integer array height of length n.
/// There are n vertical lines drawn such that the two endpoints of the ith line are (i, 0) and (i, height[i]).
/// Find two lines that together with the x-axis form a container, such that the container contains the most water.
/// Return the maximum amount of water a container can store.
/// Notice that you may not slant the container.
/// </summary>
public class ContainerWithMostWater
{
    /// <summary>
    /// Standart(Базовое решение). Решил через вычисления колличество воды внутри контейнера.
    /// 1) Вычисляем ширину, так как мы ставим 2 указателя по краям массива можно вычислить: j - i
    /// 2) В зависимости от высоты решаем какой указатель двигать что бы получить максимальное значение.
    /// </summary>
    /// <param name="height">[1,8,6,2,5,4,8,3,7]</param>
    /// <returns>49</returns>
    public int MaxArea(int[] height)
    {
        int water = 0;

        for (int i = 0, j = height.Length-1; i <= j;)
        {
            int tempWater = (j - i) * Math.Min(height[i], height[j]);
            
            if (water < tempWater) water = tempWater;

            if (height[i] < height[j]) i++;
            else j--;
        }

        return water;
    }
    
    /// <summary>
    /// Standart(Базовое решение). Решил через вычисления колличество воды внутри контейнера.
    /// 1) Вычисляем ширину, так как мы ставим 2 указателя по краям массива можно вычислить: j - i
    /// 2) Добавлена проверка на максимально возможное значение, по условиям задачи: 0 <= height[i] <= 10 000.
    /// То есть если даже теоритический максимум меньше нашего res то больше уже точно результата не найти
    /// ведь ширина постоянно уменьшается. 
    /// 3) В зависимости от высоты решаем какой указатель двигать что бы получить максимальное значение.
    /// </summary>
    /// <param name="height">[1,8,6,2,5,4,8,3,7]</param>
    /// <returns>49</returns>
    public int MaxAreaBestSpeed(int[] height) {
        int l = 0;
        int r = height.Length - 1;
        int res = 0;

        while(l < r)
        {
            res = Math.Max(res, (r - l) * Math.Min(height[l], height[r]));

            if((r - l) * 10000 < res) break;

            if(height[l] > height[r])
                r--;
            else
                l++;
        }

        return res;
    }
}