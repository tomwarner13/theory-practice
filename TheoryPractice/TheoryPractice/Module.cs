using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheoryPractice
{
  public abstract class Module
  {
    protected string Output;

    public abstract void ReadInput(string input);

    public bool HasResult => !string.IsNullOrEmpty(Output);

    public string GetResult()
    {
      var result = Output;
      Output = null;
      return result;
    }

    protected int[] ParseIntArray(string input)
    {
      if (string.IsNullOrWhiteSpace(input)) return new int[0];

      return input.Split(' ').Where(s => !string.IsNullOrWhiteSpace(s)).Select(int.Parse).ToArray();
    }
  }
}
