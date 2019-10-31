using Algos.Heaps;
using Algos.Sorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheoryPractice.Modules
{
  public class HeapTester : Module
  {
    public HeapTester()
    {
      Output = "Heap Tester: [ints] to heapify, S: [ints] to heapsort";
    }

    public override void ReadInput(string input)
    {
      var steps = 0;
      if (input[0] == 'S')
      {
        var arr = ParseIntArray(input.Split(':')[1]);

        HeapSort.Sort(ref arr, ref steps);

        Output = string.Join(" ", arr) + $": {steps}";
      }
      else
      {
        var arr = ParseIntArray(input);

        Heapifyer.Heapify(ref arr, ref steps);

        Output = string.Join(" ", arr) + $": {steps}";
      }
    }
  }
}
