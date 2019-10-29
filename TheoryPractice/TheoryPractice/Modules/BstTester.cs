using Schema.Trees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheoryPractice.Modules
{
  public class BstTester : Module
  {
    private BinarySearchTree<int> _tree;

    public BstTester()
    {
      Output = "BST Tester: B: [ints] to build, F: [int] to find, A: [int] to add";
      _tree = new BinarySearchTree<int>();
    }

    public override void ReadInput(string input)
    {
      var steps = 0;
      var parts = input.Split(':');

      var command = parts[0];

      switch (command)
      {
        case "B":
          _tree.Build(ParseIntArray(parts[1]), ref steps);
          Output = $"steps: {steps}";
          break;
        case "F":
          var result = _tree.Find(int.Parse(parts[1]), ref steps);
          Output = $"{result} : {steps}";
          break;
        case "A":
          _tree.Add(int.Parse(parts[1]), ref steps);
          Output = $"steps: {steps}";
          break;
        default:
          Output = $"invalid input: B: [ints] to build, F: [int] to find, A: [int] to add";
          break;
      }
    }
  }
}
