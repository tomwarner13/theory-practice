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

    public string GetResult => Output;
  }
}
