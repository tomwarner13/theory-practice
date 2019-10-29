using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheoryPractice.Modules
{
  public class UselessModule : Module
  {
    public override void ReadInput(string input)
    {
      Output += input;
    }
  }
}
