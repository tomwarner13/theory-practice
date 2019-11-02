using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schema.Graphs
{
  public class GraphNode
  {
    public readonly string Name;

    public GraphNode(string name)
    {
      Name = name;
      Edges = new List<Edge>();
    }

    public readonly List<Edge> Edges;
  }  
}
