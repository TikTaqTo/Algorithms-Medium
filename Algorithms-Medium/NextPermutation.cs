namespace Algorithms_Medium;

/// <summary>
/// 31. Next Permutation
/// A permutation of an array of integers is an arrangement of its members into a sequence or linear order.
/// For example, for arr = [1,2,3], the following are all the permutations of arr: [1,2,3], [1,3,2], [2, 1, 3], [2, 3, 1], [3,1,2], [3,2,1].
/// The next permutation of an array of integers is the next lexicographically greater permutation of its integer.
/// More formally, if all the permutations of the array are sorted in one container according to their lexicographical order,
/// then the next permutation of that array is the permutation that follows it in the sorted container.
/// If such arrangement is not possible, the array must be rearranged as the lowest possible order (i.e., sorted in ascending order).
/// For example, the next permutation of arr = [1,2,3] is [1,3,2].
/// Similarly, the next permutation of arr = [2,3,1] is [3,1,2].
/// While the next permutation of arr = [3,2,1] is [1,2,3] because [3,2,1] does not have a lexicographical larger rearrangement.
/// Given an array of integers nums, find the next permutation of nums.
/// The replacement must be in place and use only constant extra memory.
/// </summary>
public class NextPermutation
{
    /// <summary>
    /// Standart(Базовое решение) +BestSpeed(Лучшее по скорости - Жёлтый). Решение через указатели которые меняются местами
    /// 1) С право на лево ищем первый элемент который соответсвует условию: nums[pivot] >= nums[pivot + 1]
    /// 2) С право на лево от найденного нами приведущего шага элемента ищем какой будет меньше или равен нашему элементу
    /// 3) Меняем их местами и делаем reverse всем остальным элементам которые идут после
    /// </summary>
    /// <param name="nums">[[1, 2, 3] => [1, 3, 2]]</param>
    public void NextPermutationAnswer(int[] nums)
    {
        int pivot = nums.Length - 2;

        while (pivot >= 0 && nums[pivot] >= nums[pivot + 1])
        {
            pivot--;
        }

        if (pivot >= 0)
        {
            int successor = nums.Length - 1;
            while (nums[successor] <= nums[pivot])
            {
                successor--;
            }

            Swap(nums, pivot, successor);
        }

        Reverse(nums, pivot + 1, nums.Length - 1);
    }

    private void Swap(int[] nums, int first, int second)
    {
        int temporary = nums[first];
        nums[first] = nums[second];
        nums[second] = temporary;
    }

    private void Reverse(int[] nums, int left, int right)
    {
        while (left < right)
        {
            Swap(nums, left, right);
            left++;
            right--;
        }
    }
}