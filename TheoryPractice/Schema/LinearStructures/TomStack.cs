using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schema.LinearStructures
{
  public class TomStack<T>
  {
    private readonly QuickLinkedList<T> _stack = new QuickLinkedList<T>();

    public void Push(T item)
    {
      _stack.AddToHead(item);
    }

    public bool Any() => _stack.Count > 0;

    public T Peek() => _stack.Root.Value;

    public T Pop() => _stack.RemoveAt(0);

    public int Count => _stack.Count;
  }
}
