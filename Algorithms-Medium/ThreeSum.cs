namespace Algorithms_Medium;

/// <summary>
/// 15. 3Sum
/// Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that
/// i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.
/// Notice that the solution set must not contain duplicate triplets.
/// </summary>
public class ThreeSum
{
    /// <summary>
    /// Standart(Базовое решение) +BestSpeed(Лучшее по скорости - Жёлтый). Проходимся 2 циклами, первый цикл ходит по всем элементам массива с право на лево.
    /// Второй цикл ищет по 2 направлениям max и min если они не подходят делаем шаг в зависимости от суммы.
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public IList<IList<int>> ThreeSumAnswer(int[] nums)
    {
        IList<IList<int>> returnValue = new List<IList<int>>();
        nums.Sort();

        for (int i = 0; i < nums.Length; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1])
                continue;

            int left = i + 1;
            int right = nums.Length - 1;

            while (left < right)
            {
                int threeSum = nums[i] + nums[left] + nums[right];

                if (threeSum > 0)
                    right--;
                else if (threeSum < 0)
                    left++;
                else
                {
                    returnValue.Add([nums[i], nums[left], nums[right]]);
                    left++;
                    
                    while (nums[left] == nums[left - 1] && left < right)
                        left++;
                }
            }
        }

        return returnValue;
    }
}