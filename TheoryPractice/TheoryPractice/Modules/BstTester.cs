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
    private const string CommandText = "B: [ints] to build, F: [int] to find, A: [int] to add, M to find minimum, R: [int] to remove, D to DFT, T to BFT";

    public BstTester()
    {
      Output = $"BST Tester: {CommandText}";
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
        case "M":
          var min = _tree.Minimum(ref steps);
          Output = $"{min} : {steps}";
          break;
        case "R":
          result = _tree.Remove(int.Parse(parts[1]), ref steps);
          Output = $"{result} : {steps}";
          break;
        case "D":
          foreach(var item in _tree.DepthFirstTraverse())
          {
            Output += $"{item} ";
          }
          break;
        case "T":
          foreach (var item in _tree.BreadthFirstTraverse())
          {
            Output += $"{item} ";
          }
          break;
        default:
          Output = $"invalid input: {CommandText}";
          break;
      }
    }
  }
}
