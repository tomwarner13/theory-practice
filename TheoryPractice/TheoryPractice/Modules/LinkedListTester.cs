using Schema.LinearStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheoryPractice.Modules
{
  public class LinkedListTester : Module
  {
    private readonly QuickLinkedList<string> _list;
    private const string InstructionText = "A:name to add, H:name to add at head, R:index to remove, P to print, B to print backwards, T to remove tail";

    public LinkedListTester()
    {
      _list = new QuickLinkedList<string>();
      Output = $"LIST TESTER: {InstructionText}";
    }

    public override void ReadInput(string input)
    {
      var parts = input.Split(':');

      var command = parts[0];

      switch(command)
      {
        case "A":
          _list.Add(parts[1]);
          break;
        case "H":
          _list.AddToHead(parts[1]);
          break;
        case "R":
          _list.RemoveAt(int.Parse(parts[1]));
          break;
        case "P":
          foreach(var i in _list)
          {
            Output += i + " ";
          }
          break;
        case "B":
          foreach (var i in _list.ReadReverse())
          {
            Output += i + " ";
          }
          break;
        case "T":
          Output = _list.RemoveTail();
          break;
        default:
          Output = $"invalid input: {InstructionText}";
          break;
      }
    }
  }
}
