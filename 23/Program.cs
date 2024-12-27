using System.Collections.Immutable;
using System.IO.Pipelines;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.Marshalling;
using System.Xml.XPath;

string file = args.Length > 0 ? args[1] : @"C:\Users\yvesg\git\aoc2024\23\test.txt";

var data = File.ReadAllLines(file).ToList().Select(p =>
{
  var parts = p.Split('-');
  return (parts[0], parts[1] );
});

List<(string,string)> tuples = data.ToList();

int find(string c, int i)
{
  while (i < tuples.Count)
  {
    if (tuples[i].Item1 == c || tuples[i].Item2 == c)
    {
      return i;
    }
    i++;
  }
  return -1;
}

int find2(List<(string, string)> l, string c, int i)
{
  var l2 = l.ToList();
  while (i < l2.Count)
  {
    if (l2[i].Item1 == c || l2[i].Item2 == c)
    {
      return i;
    }
    i++;
  }
  return -1;
}


void part1()
{
  // data.ToList().ForEach(p => Console.WriteLine(p));
  int total = 0;
  HashSet<(string, string, string)> triplet = [];
  int i = 0;
  while (i < tuples.Count)
  {
    var a = tuples[i].Item1;
    var b = tuples[i].Item2;
    int j = 0;
    while (j > -1 && j < tuples.Count)
    {
      if (j == i) j++;
      j = find(b, j);
      if (j > -1)
      {
        string c = b == tuples[j].Item1 ? tuples[j].Item2 : tuples[j].Item1;
        int k = 0;
        while (k > -1 && k < tuples.Count)
        {
          // if (k == i) k++;
          // if (k == j) k++;
          k = find(c, k);
          if (k > -1)
          {
            if (k != j && k != i)
            {
              string d = c == tuples[k].Item1 ? tuples[k].Item2 : tuples[k].Item1;
              if (a == d)
              {
                List<string> result = [a, b, c];
                // Console.WriteLine($"{a} {b} {c}");
                result.Sort();
                if (!triplet.Contains((result[0], result[1], result[2])))
                {
                  triplet.Add((result[0], result[1], result[2]));
                  for (int r = 0; r < result.Count; r++)
                  {
                    if (result[r].StartsWith("t"))
                    {
                      total++;
                      break;
                    }
                  }
                }

              }
            }
            k++;
          }
        }
        j++;
      }
    }
    i++;
  }
  triplet.ToList().ForEach(p => Console.WriteLine(p));
  Console.WriteLine($"total {total}");
}

void part2()
{
  int i = 0;
  HashSet<string> computer = [];
  tuples.ForEach(tuple => {
    Console.WriteLine($"({tuple.Item1}-{tuple.Item2})");
    computer.Add(tuple.Item1);
    computer.Add(tuple.Item2);
  });
  var sortedComputers = computer.ToList();
  sortedComputers.Sort();
  sortedComputers.ToList().ForEach(c => Console.WriteLine(c));
}

// part1();

part2();