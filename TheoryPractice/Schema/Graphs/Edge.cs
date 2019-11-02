using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schema.Graphs
{
  public class Edge
  {
    public int Weight { get; set; }
    public GraphNode Node { get; set; }
  }
}
