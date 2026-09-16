using System.Runtime.Intrinsics;

namespace Algorithms_Medium;

/// <summary>
/// 2. Add Two Numbers
/// You are given two non-empty linked lists representing two non-negative integers.
/// The digits are stored in reverse order, and each of their nodes contains a single digit.
/// Add the two numbers and return the sum as a linked list.
/// You may assume the two numbers do not contain any leading zero, except the number 0 itself.
/// </summary>
public class AddTwoNumbers
{
    /// <summary>
    /// Standart(Базовое решение). Решаем через перебор каждого элемента и проверкой следующего элемента.
    /// </summary>
    /// <param name="l1"></param>
    /// <param name="l2"></param>
    /// <returns></returns>
    public ListNode? AddTwoNumbersAnswer(ListNode? l1, ListNode? l2)
    {
        if (l1 == null && l2 != null) return l2;
        if (l2 == null && l1 != null) return l1;
        if (l1 == null && l2 == null) return null;
        
        ListNode result;

        int sum = l1.val + l2.val;
        if (sum > 9)
        {
            result = new ListNode();
            result.val = sum % 10;
            if (l1.next != null & l2.next == null)
            {
                result.next = AddTwoNumbersAnswer(l1.next, new ListNode(1));
            } else if (l1.next == null & l2.next != null)
            {
                result.next = AddTwoNumbersAnswer(new ListNode(1), l2.next);
            } else if (l1.next == null & l2.next == null)
            {
                result.next = new ListNode(1);
            }
            else
            {
                l1.next.val += 1;
                result.next = AddTwoNumbersAnswer(l1.next, l2.next);
            }
        }
        else
        {
            result = new ListNode();
            result.val = sum;
            result.next = AddTwoNumbersAnswer(l1.next, l2.next);   
        }
        
        return result;
    }
    
    /// <summary>
    /// BestSpeed(Лучшее по скорости - Жёлтый). Лучшее решение по скорости, проверки не зависят друг от друга,
    /// вынесли в переменную увеличения числа при сумме > 9.
    /// </summary>
    /// <param name="l1"></param>
    /// <param name="l2"></param>
    /// <returns></returns>
    public ListNode AddTwoNumbersBestSpeed(ListNode l1, ListNode l2)
    {
        return Add(l1, l2, 0);
    }

    private ListNode Add(ListNode? l1, ListNode? l2, int carry)
    {
        // Nothing to do, at end with no carry
        if (l1 == null && l2 == null && carry == 0)
            return null;

        // At a minimum
        int sum = carry;

        // Add values from current nodes
        if (l1 != null)
            sum += l1.val;

        if (l2 != null)
            sum += l2.val;

        // Setup node with place value
        ListNode node = new ListNode(sum % 10);

        // Next node, we handle nulls so its fine
        node.next = Add(
            l1?.next,
            l2?.next,
            sum / 10 // Pass carry down
        );

        return node;
    }
}

public class ListNode {
 public int val;
 public ListNode next;
 public ListNode(int val=0, ListNode next=null) {
         this.val = val;
         this.next = next;
     }
}