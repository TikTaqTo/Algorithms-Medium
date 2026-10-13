namespace Algorithms_Medium;

/// <summary>
/// 18. 4Sum
/// Given an array nums of n integers, return an array of all the unique quadruplets [nums[a], nums[b], nums[c], nums[d]] such that:
/// 1) 0 <!--<=--> a, b, c, d <!--<--> n
/// 2) a, b, c, and d are distinct.
/// 3) nums[a] + nums[b] + nums[c] + nums[d] == target
/// You may return the answer in any order.
/// </summary>
public class FourSum
{
    /// <summary>
    /// Standart(Базовое решение). Решил через вложенные циклы и пропуск дубликатов через continue;
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public IList<IList<int>> FourSumAnswer(int[] nums, int target)
    {
        IList<IList<int>> result = new List<IList<int>>();
        if (nums == null || nums.Length < 4) return result;

        Array.Sort(nums); 
        int n = nums.Length;

        for (int left = 0; left < n - 3; left++)
        {
            if (left > 0 && nums[left] == nums[left - 1]) continue;

            for (int j = left + 1; j < n - 2; j++) 
            {
                if (j > left + 1 && nums[j] == nums[j - 1]) continue;

                int windowLeft = j + 1;
                int windowRight = n - 1;

                while (windowLeft < windowRight)
                {
                    long fourSum = (long)nums[left] + nums[j] + nums[windowLeft] + nums[windowRight];

                    if (fourSum > target)
                    {
                        windowRight--;
                    }
                    else if (fourSum < target)
                    {
                        windowLeft++;
                    }
                    else
                    {
                        result.Add([nums[left], nums[j], nums[windowLeft], nums[windowRight]]);
                        windowLeft++;
                        windowRight--;
                        
                        while (windowLeft < windowRight && nums[windowLeft] == nums[windowLeft - 1])
                            windowLeft++;
                        while (windowLeft < windowRight && nums[windowRight] == nums[windowRight + 1])
                            windowRight--;
                    }
                }
            }
        }
        
        return result;
    }
}