using Schema.LinearStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheoryPractice.Modules
{
  public class StackTester : Module
  {
    private readonly TomStack<int> _stack;
    private const string InstructionText = "U:[int] to push, O to pop, C for count";

    public StackTester()
    {
      _stack = new TomStack<int>();
      Output = $"STACK TESTER: {InstructionText}";
    }

    public override void ReadInput(string input)
    {
      var parts = input.Split(':');

      var command = parts[0];

      switch (command)
      {
        case "U":
          _stack.Push(ParseIntArray(parts[1])[0]);
          break;
        case "O":
          Output = _stack.Pop().ToString();
          break;
        case "C":
          Output = _stack.Count.ToString();
          break;
        default:
          Output = $"invalid input: {InstructionText}";
          break;
      }
    }
  }
}
