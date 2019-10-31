using Algos.Heaps;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algos.Sorts
{
  public static class HeapSort
  {
    public static void Sort(ref int[] arr, ref int steps)
    {
      for(var i = 0; i < arr.Length - 1; i++)
      {
        Heapifyer.HeapifyRange(ref arr, i, arr.Length - 1, ref steps);
      }
    }
  }
}
