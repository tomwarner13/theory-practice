using Algos.Sorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schema.Trees
{
  public class BinarySearchTree<T> where T : IComparable<T>
  {
    public BSTNode<T> Root; //would it be better to store these as pointers to BSTs? huh?

    public void Build(IList<T> values, ref int steps)
    {
      //is there a better way to do this than add? must be cause that would give you a weird shaped tree depending on data order
      //probably sort, then build from median of each side

      //dogfooding yo
      var sorted = MergeSort.Sort(values.ToArray(), ref steps);

      var midpoint = sorted.Count() / 2;
      Root = new BSTNode<T>(sorted[midpoint]);

      BuildInternal(sorted.Take(midpoint).ToList(), Root, ref steps);
      BuildInternal(sorted.Skip(midpoint + 1).ToList(), Root, ref steps);
    }

    private void BuildInternal(IList<T> values, BSTNode<T> parent, ref int steps) //note that this assumes list already got sorted
    {
      steps++;
      if (!values.Any()) return;

      var midpoint = values.Count / 2;

      var valueToInsert = values[midpoint];

      if(parent.Value.CompareTo(valueToInsert) >= 0) //slide left in tie
      {
        parent.Left = new BSTNode<T>(valueToInsert);
        BuildInternal(values.Take(midpoint - 1).ToList(), parent.Left, ref steps);
        BuildInternal(values.Skip(midpoint + 1).ToList(), parent.Left, ref steps);
      }
      else
      {
        parent.Right = new BSTNode<T>(valueToInsert);
        BuildInternal(values.Take(midpoint - 1).ToList(), parent.Right, ref steps);
        BuildInternal(values.Skip(midpoint + 1).ToList(), parent.Right, ref steps);
      }
    }

    public void Add(T value, ref int steps)
    {
      AddInternal(value, Root, ref steps);
    }

    private void AddInternal(T value, BSTNode<T> node, ref int steps)
    {
      steps++;
      if (node.Value.CompareTo(value) >= 0) //slide to the left in a tie
      {
        if (node.Left == null)
        {
          node.Left = new BSTNode<T>(value);
        }
        else
        {
          AddInternal(value, node.Left, ref steps);
        }
      }
      else
      {
        if (node.Right == null)
        {
          node.Right = new BSTNode<T>(value);
        }
        else
        {
          AddInternal(value, node.Right, ref steps);
        }
      }
    }

    public bool Find(T needle, ref int steps)
    {
      return FindInternal(needle, Root, ref steps);
    }

    private bool FindInternal(T needle, BSTNode<T> node, ref int steps)
    {
      steps++;
      if (node.Value.CompareTo(needle) == 0) return true;

      if(node.Value.CompareTo(needle) > 0)
      {
        if (node.Left == null) return false;
        return FindInternal(needle, node.Left, ref steps);
      }
      else
      {
        if (node.Right == null) return false;
        return FindInternal(needle, node.Right, ref steps);
      }
    }
    
    public bool Remove(T target, ref int steps)
    {
      throw new NotImplementedException();
    }

    //TODO maybe: traverses? as review later on?
  }

  public class BSTNode<T>
  {
    public BSTNode<T> Left;
    public BSTNode<T> Right;
    public T Value;

    public BSTNode(T value)
    {
      Value = value;
    }
  }
}
