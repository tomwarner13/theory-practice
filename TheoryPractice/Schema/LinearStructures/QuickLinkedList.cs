using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Schema.LinearStructures
{
  public class QuickLinkedList<T> : IEnumerable<T>
  {
    public Node<T> Root { get; private set; }
    public Node<T> Tail { get; private set; }
    public int Count { get; private set; } = 0;
    
    public void Add(T item)
    {
      if (Root == null) Root = new Node<T>(item);
      if (Tail == null) Tail = Root;
      else
      {
        Node<T> current = Tail;

        Tail = new Node<T>(item);

        current.Next = Tail;
        Tail.Previous = current;
      }

      Count++;
    }

    public void AddToHead(T item)
    {
      var oldRoot = Root;
      Root = new Node<T>(item);
      if (Tail == null) Tail = Root;
      Root.Next = oldRoot;
      if(oldRoot != null) oldRoot.Previous = Root;
      Count++;
    }

    public T RemoveAt(int index)
    {
      if(index > Count || index < 0) throw new ArgumentOutOfRangeException($"Index {index} is out of bounds of the list");

      Node<T> result;

      if (index == 0)
      {
        result = Root;
        Root = Root.Next;
        if (Root == null)
        {
          Tail = null;
        }
        else
        {
          Root.Previous = null;
        }
      }
      else if(index == Count - 1)
      {
        result = Tail;
        Tail = Tail.Previous;
        Tail.Next = null;
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

        result = currentNode;
        previousNode.Next = currentNode.Next;
        currentNode.Next.Previous = previousNode;
      }

      Count--;
      return result.Value;
    }

    public T RemoveTail()
    {
      var tail = Tail;

      if(Tail.Previous == null)
      {
        Tail = null;
        Root = null;
      }
      else
      {
        Tail = Tail.Previous;
        Tail.Next = null;
      }

      Count--;
      return tail.Value;
    }

    public IEnumerable<T> ReadReverse()
    {
      var node = Tail;
      while(node != null)
      {
        yield return node.Value;
        node = node.Previous;
      }
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
      public Node<T1> Previous;
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
