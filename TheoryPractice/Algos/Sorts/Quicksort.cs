using System;
using System.Collections.Generic;
using System.Text;

namespace Algos.Sorts
{
  public class Quicksort<T> where T : IComparable<T>
  {
    public static int Sort(ref T[] arr)
    {
      var stepsTaken = 0;
      SortRange(ref arr, 0, arr.Length - 1, ref stepsTaken);
      return stepsTaken;
    }

    private static void SortRange(ref T[] arr, int startIndex, int endIndex, ref int steps)
    {
      if(startIndex < endIndex)
      {
        var pivot = Partition(ref arr, startIndex, endIndex, ref steps);
        SortRange(ref arr, startIndex, pivot - 1, ref steps);
        SortRange(ref arr, pivot + 1, endIndex, ref steps);
      }
    }

    private static int Partition(ref T[] arr, int startIndex, int endIndex, ref int steps)
    {
      var pivotVal = arr[endIndex];
      var index = startIndex;

      for (var i = startIndex; i <= endIndex; i++)
      {
        if(arr[i].CompareTo(pivotVal) < 0)
        {
          var temp = arr[i];
          arr[i] = arr[index];
          arr[index] = temp;
          index++;
        }
        steps++;
      }
      var temp2 = arr[index];
      arr[index] = arr[endIndex];
      arr[endIndex] = temp2;
      steps++;

      return index;
    }
  }
}
