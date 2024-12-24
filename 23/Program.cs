using System.IO.Pipelines;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.Marshalling;
using System.Xml.XPath;

string file = args.Length > 0 ? args[1] : @"C:\Users\yvesg\git\aoc2024\23\test.txt";

var data = File.ReadAllLines(file).ToList().Select(p =>
{
  var parts = p.Split('-');
  return new[] { parts[0], parts[1] };
});

var tuples = data.ToList();

int find(string c, int i)
{
  while (i < tuples.Count)
  {
    if (tuples[i][0] == c || tuples[i][1] == c)
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
    var a = tuples[i][0];
    var b = tuples[i][1];
    int j = 0;
    while (j > -1 && j < tuples.Count)
    {
      if (j == i) j++;
      j = find(b, j);
      if (j > -1)
      {
        string c = b == tuples[j][0] ? tuples[j][1] : tuples[j][0];
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
              string d = c == tuples[k][0] ? tuples[k][1] : tuples[k][0];
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
  List<List<string>> lans = [];
  while (i < tuples.Count)
  {
    var a = tuples[i][0];
    var b = tuples[i][1];
    List<string> lan = [a];
    int j = 0;
    while (j > -1)
    {
      j = find(b, j);
      if (j != i && j > -1)
      {
        lan.Add(b);
        b = b == tuples[j][0] ? tuples[j][1] : tuples[j][0];
      }
      if (j > -1 ) j++;
    }
    lans.Add(lan);
    i++;
  }
  lans.ToList().ForEach(lan => {
    lan.ToList().ForEach(l => Console.Write($"{l} "));
    Console.WriteLine();
  });

}

// part1();

part2();
