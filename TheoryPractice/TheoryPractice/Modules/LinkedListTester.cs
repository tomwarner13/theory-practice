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

    public LinkedListTester()
    {
      _list = new QuickLinkedList<string>();
      Output = "LIST TESTER: A:name to add, R:index to remove, P to print";
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
        case "R":
          _list.RemoveAt(int.Parse(parts[1]));
          break;
        case "P":
          foreach(var i in _list)
          {
            Output += i + " ";
          }
          break;
        default:
          Output = $"invalid input: A:name to add, R:index to remove, P to print";
          break;
      }
    }
  }
}
