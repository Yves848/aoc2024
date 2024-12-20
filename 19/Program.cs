using System.Data.Common;
using Microsoft.VisualBasic;

string input = @"C:\Users\yvesg\git\aoc2024\19\data.txt";
if (args.Length > 0)
{
  input = args[0];
}

if (!File.Exists(input))
{
  Environment.Exit(-1);
}

var data = File.ReadAllText(input).Split("\r\n\r\n");
// var pattern = new PriorityQueue<string, int>(Comparer<int>.Create((x, y) => y.CompareTo(x)));
List<string> pattern = [];
data[0].Split(',').ToList().ForEach(p =>
{
  // pattern.Enqueue(p.Trim(), p.Trim().Length);
  pattern.Add(p.Trim());
});
// var sortedPattern = pattern.UnorderedItems.OrderBy(item => item.Priority).Reverse();
Dictionary<string,int> DP = new Dictionary<string, int>();
int validTowel(string towel)
{
  Console.WriteLine($" Towel {towel}");
  if (DP.ContainsKey(towel)) return DP[towel];
  int result = 0;
  if (towel.Trim() == "") result = 1;
  pattern.ForEach(p =>
  {
    // if (towel.Length >= p.Length) 
    if (towel.StartsWith(p))
    {
      Console.Write($"Pattern {p}");
      result += validTowel(towel[p.Length..]);
    }
  });
  DP[towel] = result;
  return result;
}

void part1()
{
  HashSet<string> possible = [];
  int total = 0;
  data[1].Split("\r\n").ToList().ForEach(towel =>
  {
    if (validTowel(towel) > 0) total++;
    Console.WriteLine($"FullTowel {towel}");
  });
  Console.WriteLine($"Total = {total}");
}

void part2()
{

}

part1();

part2();