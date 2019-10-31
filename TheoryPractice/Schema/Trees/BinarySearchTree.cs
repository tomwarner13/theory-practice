using Algos.Sorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schema.Trees
{
  public class BinarySearchTree<T> where T : IComparable<T>
  {
    public BSTNode<T> Root;

    public void Build(IList<T> values, ref int steps)
    {
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
        BuildInternal(values.Take(midpoint).ToList(), parent.Left, ref steps);
        BuildInternal(values.Skip(midpoint + 1).ToList(), parent.Left, ref steps);
      }
      else
      {
        parent.Right = new BSTNode<T>(valueToInsert);
        BuildInternal(values.Take(midpoint).ToList(), parent.Right, ref steps);
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

    public T Minimum(ref int steps)
    {
      return MinimumInternal(Root, ref steps).Min.Value;
    }

    private (BSTNode<T> Min, BSTNode<T> Parent) MinimumInternal(BSTNode<T> root, ref int steps)
    {
      steps++;
      BSTNode<T> parent = null;
      var node = root;
      while(node?.Left != null)
      {
        parent = node;
        node = node.Left;
        steps++;
      }
      return (node, parent);
    }

    public bool Find(T needle, ref int steps)
    {
      return FindInternal(needle, Root, ref steps) != null;
    }

    private BSTNode<T> FindInternal(T needle, BSTNode<T> node, ref int steps)
    {
      steps++;
      if (node.Value.CompareTo(needle) == 0) return node;

      if(node.Value.CompareTo(needle) > 0)
      {
        if (node.Left == null) return null;
        return FindInternal(needle, node.Left, ref steps);
      }
      else
      {
        if (node.Right == null) return null;
        return FindInternal(needle, node.Right, ref steps);
      }
    }
    
    public bool Remove(T target, ref int steps)
    {
      return RemoveInternal(target, Root, null, ref steps);
    }

    private bool RemoveInternal(T target, BSTNode<T> node, BSTNode<T> parentNode, ref int steps)
    {
      steps++;

      if(target.CompareTo(node.Value) == 0) //found the node to remove
      {
        if(node.Left == null && node.Right == null) //no children, just kill it
        {
          if (node == parentNode.Left) parentNode.Left = null;
          else parentNode.Right = null;
        }
        else if (node.Left != null && node.Right == null) //only left child
        {
          if (node == Root) Root = node.Left;
          else if (node == parentNode.Left) parentNode.Left = node.Left;
          else parentNode.Right = node.Left;
        }
        else if (node.Left == null && node.Right != null) //only right child
        {
          if (node == Root) Root = node.Right;
          else if (node == parentNode.Left) parentNode.Left = node.Right;
          else parentNode.Right = node.Right;
        }
        else //2 children so we need to replace this node with the next available value
        {
          var (Min, Parent) = MinimumInternal(node.Right, ref steps);
          node.Value = Min.Value;
          RemoveInternal(Min.Value, Min, Parent ?? node, ref steps);
        }
        return true;
      }
      else if(target.CompareTo(node.Value) < 0) //go left
      {
        if (node.Left == null) return false; //we haven't found a node to remove
        return RemoveInternal(target, node.Left, node, ref steps);
      }
      else //go right
      {
        if (node.Right == null) return false; //we haven't found a node to remove
        return RemoveInternal(target, node.Right, node, ref steps);
      }
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
