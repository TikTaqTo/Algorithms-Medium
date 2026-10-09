namespace Algorithms_Medium;

/// <summary>
/// 16. 3Sum Closest
/// You are given an integer array nums of length n and an integer target.
/// Find three integers at distinct indices in nums such that the sum is closest to target.
/// Return the sum of the three integers.
/// You may assume that each input would have exactly one solution.
/// </summary>
public class SumClosest 
{
    /// <summary>
    /// Standart(Базовое решение). Проходимся по массиву 3 указателями, min и max и i.
    /// 1) Сортируем массив.
    /// 2) В зависимости от результата подтягиваем левый или правый указатель массива min и max.
    /// </summary>
    /// <param name="nums">[-1,2,1,-4]</param>
    /// <param name="target">1</param>
    /// <returns>2</returns>
    public int ThreeSumClosest(int[] nums, int target)
    {
        nums.Sort();
        
        int closestSum = nums[0] + nums[1] + nums[2];
        
        for (int i = 0; i < nums.Length - 2; i++) {
            if (i > 0 && nums[i] == nums[i - 1]) {
                continue;
            }
            
            int left = i + 1;
            int right = nums.Length - 1;
            
            while (left < right) {
                int currentSum = nums[i] + nums[left] + nums[right];
                
                if (currentSum == target) {
                    return currentSum;
                }
                
                if (Math.Abs(currentSum - target) < Math.Abs(closestSum - target)) {
                    closestSum = currentSum;
                }
                
                if (currentSum < target) {
                    left++;
                } else {
                    right--;
                }
            }
        }
        
        return closestSum;
    }
}