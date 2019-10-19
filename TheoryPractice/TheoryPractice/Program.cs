using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheoryPractice
{
  public class Program
  {
    public static void Main(string[] args)
    {
      //main interface
      //big ol REPL basically, go through possible tools and run em, return output to console

      var assemblies = AppDomain.CurrentDomain.GetAssemblies();
      var modules = new Dictionary<int, ModuleInfo>();

      var i = 0;

      foreach (var assembly in assemblies)
      {
        var assemblyModules = (from t in assembly.GetTypes()
                               where t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(Module))
                               select new ModuleInfo { Name = t.Name, Module = t});

        foreach(var module in assemblyModules)
        {
          modules[i] = module;
          i++;
        }
      }

      var sb = new StringBuilder("Possible modules: [number] loads the requested module, [h] prints this text, [:x] exits module, [q] quits:\n");

      foreach(var module in modules.OrderBy(kvp => kvp.Key))
      {
        sb.AppendLine($"{module.Key}: {module.Value.Name}");
      }

      var helpText = sb.ToString();

      Console.WriteLine(helpText);

      var keepLooping = true;
      while(keepLooping)
      {
        var input = Console.ReadLine();
        switch(input)
        {
          case "h":
            Console.WriteLine(helpText);
            break;
          case "q":
            Console.WriteLine("ya sure?");
            keepLooping = Console.ReadLine() != "y";
            break;
          default:
            if(int.TryParse(input, out var moduleNum))
            {
              if(modules.ContainsKey(moduleNum))
              {
                var selectedModule = modules[moduleNum];

                Console.WriteLine($"Entering module: {moduleNum}");

                var inModule = true;
                var module = (Module)Activator.CreateInstance(selectedModule.Module);

                while(inModule)
                {
                  try
                  {
                    var moduleInput = Console.ReadLine();
                    switch (moduleInput)
                    {
                      case ":x":
                        inModule = false;
                        break;
                      default:
                        module.ReadInput(moduleInput);
                        if (module.HasResult)
                        {
                          Console.WriteLine(module.GetResult);
                        }
                        break;
                    }
                  }
                  catch(Exception e)
                  {
                    Console.WriteLine($"module error: {e.Message}");
                  }
                }
              }
              else
              {
                Console.WriteLine($"Invalid input: {moduleNum} is not a valid module number");
              }
            }
            else
            {
              Console.WriteLine("Invalid input: please input a valid module number, or [h] for help");
            }
            break;
        }
      }

      Console.WriteLine("please press the [ANY] key to exit");
      Console.ReadKey();
    }

    private class ModuleInfo
    {
      public string Name;
      public Type Module;
    }
  }
}
