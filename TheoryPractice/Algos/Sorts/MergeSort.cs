using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algos.Sorts
{
  public class MergeSort
  {
    public static T[] Sort<T>(T[] arr, ref int steps) where T : IComparable<T>
    {
      if(arr.Length <= 1)
      {
        return arr;
      }
      var split = arr.Length / 2;
      var leftArr = arr.Take(split).ToArray();
      var rightArr = arr.Skip(split).ToArray();

      return Merge(Sort(leftArr, ref steps), Sort(rightArr, ref steps), ref steps);
    }


    private static T[] Merge<T>(T[] left, T[] right, ref int steps) where T : IComparable<T>
    {
      var finalArr = new T[left.Length + right.Length];
      var leftIndex = 0;
      var rightIndex = 0;
      var finalIndex = 0;

      while (leftIndex < left.Length || rightIndex < right.Length)
      {
        if (leftIndex == left.Length)
        {
          finalArr[finalIndex] = right[rightIndex];
          rightIndex++;
        }
        else if (rightIndex == right.Length)
        {
          finalArr[finalIndex] = left[leftIndex];
          leftIndex++;
        }
        else
        {
          //grab both, compare
          if(left[leftIndex].CompareTo(right[rightIndex]) <= 0) //greedy means stable so this grabs the leftmost value in a tie
          {
            finalArr[finalIndex] = left[leftIndex];
            leftIndex++;
          }
          else
          {
            finalArr[finalIndex] = right[rightIndex];
            rightIndex++;
          }
        }

        steps++;
        finalIndex++;
      }

      return finalArr;
    }
  }
}
