using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Replace_Words
{
  class Program
  {
    static void Main(string[] args)
    {
      List<string> dictionary = new List<string>() { "aaa", "aaaa", "a", "aa" };
      var sentence = "a aa a aaaa aaa aaa aaa aaaaaa bbb baba ababa";// Output: "a a a a a a a a bbb baba a"
      Program p = new Program();
      Console.WriteLine(p.ReplaceWords_UsingHashSet(dictionary, sentence));
    }

    public string ReplaceWords(IList<string> dictionary, string sentence)
    {
      StringBuilder output = new StringBuilder();
      var orderedDic = dictionary.Select(x => new
      {
        val = x,
        length = x.Length
      }).OrderBy(x => x.length).ToList();
      dictionary = orderedDic.Select(x => x.val).ToList();
      bool matchFound = false;
      foreach(string word in sentence.Split(" "))
      {
        foreach(string key in dictionary)
        {
          if (word.StartsWith(key))
          {
            output.Append(key);
            output.Append(" ");
            matchFound = true;
            break;
          }
        }
        if (!matchFound)
        {
          output.Append(word);
          output.Append(" ");
        }
        matchFound = false;
      }

      string finalOutput = output.ToString();
      return finalOutput.Trim();
    }

    public string ReplaceWords_UsingHashSet(IList<string> dict, string sentence)
    {
      if (dict == null || dict.Count == 0) return sentence;

      HashSet<string> set = new HashSet<string>();
      foreach (string s in dict) set.Add(s);

      StringBuilder sb = new StringBuilder();
      string[] words = sentence.Split(" ");

      foreach (string word in words)
      {
        string prefix = "";
        for (int i = 1; i <= word.Length; i++)
        {
          prefix = word.Substring(0, i);
          if (set.Contains(prefix)) break;
        }
        sb.Append(" " + prefix);
      }

      return sb.ToString().Trim();
    }
  }
}
