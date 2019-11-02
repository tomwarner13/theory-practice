using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schema.Graphs
{
  public class UndirectedGraph
  {
    public readonly Dictionary<string, GraphNode> NodesByName = new Dictionary<string, GraphNode>();
  }
}