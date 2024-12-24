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
Dictionary<string, int> DP = new Dictionary<string, int>();
int validTowel(string target)
{
  Console.WriteLine($"target {target}");
  if (DP.ContainsKey(target)) return DP[target];
  int result = 0;
  if (string.IsNullOrEmpty(target.Trim())) result = 1;
  else
  {
    pattern.ForEach(p =>
    {
      // if (towel.Length >= p.Length) 
      if (target.Trim() != "")
        if (target.StartsWith(p.Trim()))
        {
          // Console.Write($"Pattern {p}");
          result += validTowel(target.Substring(p.Length));
        }
    });
  }
  DP[target] = result;
  return result;
}

void part1()
{
  HashSet<string> possible = [];
  int total = 0;
  data[1].Split("\r\n").ToList().ForEach(towel =>
  {
    Console.WriteLine($"Towel  {towel}");
    if (validTowel(towel) > 0) total++;
    Console.WriteLine($"Total = {total}");
    // Console.WriteLine($"FullTowel {towel}");
  });
  Console.WriteLine($"Total = {total}");
}

void part2()
{

}

part1();

part2();