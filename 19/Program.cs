using Microsoft.VisualBasic;

string input = @"C:\Users\yvesg\git\aoc2024\19\test.txt";
if (args.Length > 0)
{
  input = args[0];
}

if (!File.Exists(input))
{
  Environment.Exit(-1);
}

var data = File.ReadAllText(input).Split("\r\n\r\n");
var pattern = new PriorityQueue<string, int>(Comparer<int>.Create((x, y) => y.CompareTo(x)));
data[0].Split(',').ToList().ForEach(p =>
{
  pattern.Enqueue(p.Trim(), p.Trim().Length);
});
var sortedPattern = pattern.UnorderedItems.OrderBy(item => item.Priority).Reverse();

void part1()
{
  HashSet<string> possible = [];
  int total = 0;
  data[1].Split("\r\n").ToList().ForEach(towel =>
  { 
    // Console.Write($"Towel {towel}");
    foreach (var (p, l) in sortedPattern)
    {
      while (towel.StartsWith(p)) {
        towel = towel.Remove(0,l);
      }
    }
    if (towel.Length == 0) total++;
  });
  Console.WriteLine($"Total = {total}");
}

void part2()
{

}

part1();

part2();