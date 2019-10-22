using Schema.HashTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheoryPractice.Modules
{
  public class HashTableTester : Module
  {
    private readonly DumbHashTable<string> _hashTable;

    public HashTableTester()
    {
      int GetHash(string s)
      {
        var hashCode = 0;
        for (var i = 0; i < s.Length; i++)
        {
          hashCode += (s[i] * (i + 1));
        }
        return hashCode;
      }

      _hashTable = new DumbHashTable<string>(GetHash);
      Output = "HASH TESTER: A:name to add, S:name to search, R:name to remove, P to print (not implemented)";
    }

    public override void ReadInput(string input)
    {
      var parts = input.Split(':');

      var command = parts[0];

      switch (command)
      {
        case "A":
          Output = _hashTable.AddItem(parts[1]).ToString();
          break;
        case "R":
          Output = _hashTable.Remove(parts[1]).ToString();
          break;
        case "S":
          Output = _hashTable.Contains(parts[1]).ToString();
          break;
        default:
          Output = $"invalid input: A:name to add, R:index to remove, P to print";
          break;
      }
    }
  }
}
