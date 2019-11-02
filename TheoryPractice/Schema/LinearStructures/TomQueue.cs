using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schema.LinearStructures
{
  public class TomQueue<T>
  {
    private readonly QuickLinkedList<T> _queue = new QuickLinkedList<T>();

    public void EnQueue(T item)
    {
      _queue.AddToHead(item);
    }

    public T DeQueue()
    {
      return _queue.RemoveTail();
    }

    public IEnumerable<T> Read()
    {
      return _queue;
    }

    public int Count => _queue.Count;
  }
}
