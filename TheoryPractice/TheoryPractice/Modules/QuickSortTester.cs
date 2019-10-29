using Algos.Sorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheoryPractice.Modules
{
  public class QuickSortTester : Module
  {
    public QuickSortTester()
    {
      Output = "QUICKSORT TESTER: enter space-separated list of ints for sorting";
    }

    public override void ReadInput(string input)
    {
      var arr = input.Split(' ').Select(int.Parse).ToArray();

      var steps = Quicksort<int>.Sort(ref arr);

      Output = string.Join(" ", arr) + $": {steps}";
    }
  }
}
