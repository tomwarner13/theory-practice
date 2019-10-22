using Schema.LinearStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schema.HashTables
{
  /// <summary>
  /// not thread safe
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public class DumbHashTable<T> where T : IEquatable<T>
  {
    private int _size;
    private int _count;
    private QuickLinkedList<T>[] _table;
    private readonly Func<T, int> _hashFunc;

    public DumbHashTable(Func<T, int> hashFunc, int size = 17)
    {
      _size = size;
      _hashFunc = hashFunc;
      _table = new QuickLinkedList<T>[_size];
      _count = 0;
    }

    public bool AddItem(T item)
    {
      //check if table needs to be resized first
      //TODO: find out how Real Nerds implement this
      if (ShouldResize()) Resize();

      var result = AddToTable(_table, item, GetHash);

      if(!result) _count++;
      return result;
    }

    public bool Contains(T item)
    {
      var hashCode = GetHash(item);

      var bucket = _table[hashCode];

      if (bucket == null) return false;

      foreach (var entry in bucket)
      {
        if (EqualityComparer<T>.Default.Equals(entry, item)) return true;
      }

      return false;
    }

    public bool Remove(T item)
    {
      var bucket = _table[GetHash(item)];

      if (bucket == null) return false;

      var i = 0;
      foreach(var entry in bucket)
      {
        if (EqualityComparer<T>.Default.Equals(entry, item))
        {
          bucket.RemoveAt(i);
          _count--;

          //if we were potentially shrinking the table, this is where it would be implemented

          return true;
        }
        i++;
      }

      return false;
    }

    private bool ShouldResize()
    {
      var newCount = _count + 1;

      var resizeThreshold = _size / 3; //fuck it lmao

      return newCount > resizeThreshold;
    }

    private void Resize()
    {
      var newSize = GetNextPrime(_size * 3);
      var newTable = new QuickLinkedList<T>[newSize];
      int newHashFunc(T i) => GetHash(i, newSize);

      foreach (var bucket in _table.Where(b => b != null))
      {
        foreach(var item in bucket)
        {
          AddToTable(newTable, item, newHashFunc);
        }
      }

      _size = newSize;
      _table = newTable;
    }

    private int GetNextPrime(int startIndex)
    {
      if (startIndex % 2 == 0) startIndex++;

      var i = startIndex + 2; //skip even numbers

      for (; i < int.MaxValue; i += 2)
      {
        if (IsPrime(i)) return i;
      }

      return i; //might int overflow ehhhhhhh
    }

    private bool IsPrime(int num)
    {
      var sqrt = (int)Math.Sqrt(num);

      for(var i = 2; i <= sqrt; i++)
      {
        if(num / (double)i == (num / i))
        {
          return false;
        }
      }

      return true;
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="table"></param>
    /// <param name="item"></param>
    /// <param name="hashFunc"></param>
    /// <returns>True if the item already exists in the hashtable</returns>
    private static bool AddToTable(QuickLinkedList<T>[] table, T item, Func<T, int> hashFunc)
    {
      var hashCode = hashFunc(item);

      var bucket = table[hashCode];

      if (bucket == null)
      {
        table[hashCode] = new QuickLinkedList<T>();
        bucket = table[hashCode];
      }

      foreach(var entry in bucket)
      {
        if (EqualityComparer<T>.Default.Equals(entry, item))
          return true;
      }

      bucket.Add(item);
      return false;
    }

    private int GetHash(T item)
      => _hashFunc(item) % _size;

    private int GetHash(T item, int size)
      => _hashFunc(item) % size;
  }
}
