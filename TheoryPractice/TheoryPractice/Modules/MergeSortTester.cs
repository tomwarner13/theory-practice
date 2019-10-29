using Algos.Sorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheoryPractice.Modules
{
  public class MergeSortTester : Module
  {
    public MergeSortTester()
    {
      Output = "MERGESORT TESTER: enter space-separated list of ints for sorting";
    }

    public override void ReadInput(string input)
    {
      var arr = input.Split(' ').Where(s => !string.IsNullOrWhiteSpace(s)).Select(int.Parse).ToArray();

      var steps = 0;
      var result = MergeSort.Sort(arr, ref steps);

      Output = string.Join(" ", result) + $": {steps}";
    }
  }
}
