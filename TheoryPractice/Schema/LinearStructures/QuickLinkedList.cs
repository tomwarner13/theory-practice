using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Schema.LinearStructures
{
  public class QuickLinkedList<T> : IEnumerable<T>
  {
    public Node<T> Root { get; private set; }
    public int Count { get; private set; } = 0;
    
    public void Add(T item)
    {
      //TODO if you track the last node this becomes O(1)
      if (Root == null) Root = new Node<T>(item);
      else
      {
        Node<T> current = Root;

        while(current.Next != null)
        {
          current = current.Next;
        }

        current.Next = new Node<T>(item);
      }

      Count++;
    }

    public void RemoveAt(int index)
    {
      if(index > Count || index < 0) throw new ArgumentOutOfRangeException($"Index {index} is out of bounds of the list");

      if (index == 0)
      {
        Root = Root.Next;
      }
      else
      {
        var currentNode = Root;
        Node<T> previousNode = null;

        for (int i = 0; i < index; i++)
        {
          previousNode = currentNode;
          currentNode = currentNode.Next;
        }

        previousNode.Next = currentNode.Next;
      }

      Count--;
    }

    public IEnumerator<T> GetEnumerator()
    {
      return new LinkedListEnumerator<T>(this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return new LinkedListEnumerator<T>(this);
    }

    public class Node<T1>
    {
      public Node(T1 item)
      {
        Value = item;
      }
      
      public Node<T1> Next;
      public readonly T1 Value;
    }

    public class LinkedListEnumerator<T2> : IEnumerator<T2>
    {
      private QuickLinkedList<T2>.Node<T2> _current;
      private readonly QuickLinkedList<T2>.Node<T2> _root;

      internal LinkedListEnumerator(QuickLinkedList<T2> list)
      {
        _root = list.Root;
        _current = null;
      }

      public T2 Current => _current.Value;

      object IEnumerator.Current => _current.Value;

      public void Dispose() {  }

      public bool MoveNext()
      {
        if (_current == null)
        {
          _current = _root;
          return _current != null;
        }

        _current = _current.Next;
        return _current != null;
      }

      public void Reset()
      {
        _current = null;
      }
    }
  }
}
