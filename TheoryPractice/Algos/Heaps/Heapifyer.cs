using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algos.Heaps
{
  public static class Heapifyer
  {
    public static void Heapify(ref int[] arr, ref int steps)
    {
      HeapifyRange(ref arr, 0, arr.Length - 1, ref steps);
    }


    public static void HeapifyRange(ref int[] arr, int startIndex, int endIndex, ref int steps)
    {
      var totalRange = endIndex - startIndex;
      if (totalRange < 0) throw new ArgumentOutOfRangeException(nameof(startIndex), $"endIndex ({endIndex}) must be >= startIndex ({startIndex})");

      var lastInternalNode = ((totalRange - 1) / 2) + startIndex;

      for(var i = lastInternalNode; i >= startIndex; i--)
      {
        BubbleDown(ref arr, i, startIndex, endIndex, ref steps);
      }
    }

    private static void Swap(ref int[] arr, int i, int j)
    {
      var tmp = arr[i];
      arr[i] = arr[j];
      arr[j] = tmp;
    }

    private static void BubbleDown(ref int[] arr, int i, int startIndex, int endIndex, ref int steps)
    {
      var childIndexToSwap = -1;
      var minVal = int.MaxValue;

      foreach(var child in FindChildren(i, startIndex, endIndex))
      {
        steps++;
        if(arr[child] < arr[i] && arr[child] <= minVal)
        {
          childIndexToSwap = child;
          minVal = arr[child];
        }
      }

      if(childIndexToSwap > 0)
      {
        steps++;
        Swap(ref arr, i, childIndexToSwap);
        BubbleDown(ref arr, childIndexToSwap, startIndex, endIndex, ref steps);
      }
    }

    private static IEnumerable<int> FindChildren(int i, int startIndex, int endIndex)
    {
      var relIndex = i - startIndex;

      return new[] { (relIndex * 2) + 1, (relIndex * 2) + 2 }.Where(index => index + startIndex <= endIndex).Select(index => index + startIndex);
    }
  }
}
