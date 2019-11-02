using Schema.LinearStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheoryPractice.Modules
{
  public class QueueTester : Module
  {
    private readonly TomQueue<int> _queue;
    private const string InstructionText = "E:[int] to enqueue, D to dequeue, P to print";

    public QueueTester()
    {
      _queue = new TomQueue<int>();
      Output = $"QUEUE TESTER: {InstructionText}";
    }

    public override void ReadInput(string input)
    {
      var parts = input.Split(':');

      var command = parts[0];

      switch (command)
      {
        case "E":
          _queue.EnQueue(ParseIntArray(parts[1])[0]);
          break;
        case "D":
          Output = _queue.DeQueue().ToString();
          break;
        case "P":
          foreach (var i in _queue.Read())
          {
            Output += i + " ";
          }
          break;
        default:
          Output = $"invalid input: {InstructionText}";
          break;
      }
    }
  }
}
