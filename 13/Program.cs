using System.Text.RegularExpressions;

string[] puzzle = File.ReadAllLines(@"C:\Users\yvesg\git\aoc2024\13\data.txt");
string movement = @"X\+(\d*)|Y\+(\d*)";
Regex mvt = new Regex(movement);
string prize = @"X\=(\d*)|Y\=(\d*)";
Regex prz = new Regex(prize);

List<(ulong, ulong)> pressions(ulong x1, ulong x2, ulong target)
{
  ulong nb = 1;
  ulong nb2 = 1;
  ulong total = (x1 * nb + x2 * nb2);
  List<(ulong, ulong)> result = new List<(ulong, ulong)>();
  while (total <= target)
  {
    while (total <= target)
    {

      if (total == target)
      {

        result.Add((nb, nb2));
      }
      nb2++;
      total = (x1 * nb + x2 * nb2);
    }
    nb2 = 1;
    nb++;
    total = (x1 * nb + x2 * nb2);
  };
  return result;
}

ulong tokens((ulong, ulong) button)
{
  var (a, b) = button;
  return a * 3 + b;
}

void part1()
{
  ulong cost = 0;
  (ulong, ulong) X = (0, 0);
  (ulong, ulong) Y = (0, 0);
  (ulong, ulong) P = (0, 0);
  puzzle.ToList().ForEach(line =>
  {
    if (line.Trim() != "")
    {
      if (line.Contains("A:"))
      {
        var nums = mvt.Matches(line);
        X.Item1 = ulong.Parse(nums[0].Groups[1].Value);
        Y.Item1 = ulong.Parse(nums[1].Groups[2].Value);
      }
      if (line.Contains("B:"))
      {
        var nums = mvt.Matches(line);
        X.Item2 = ulong.Parse(nums[0].Groups[1].Value);
        Y.Item2 = ulong.Parse(nums[1].Groups[2].Value);
      }
      if (line.Contains("Prize:"))
      {
        var prizes = prz.Matches(line);
        P.Item1 = ulong.Parse(prizes[0].Groups[1].Value);
        P.Item2 = ulong.Parse(prizes[1].Groups[2].Value);
        var ButtonA = pressions(X.Item1, X.Item2, P.Item1);
        var ButtonB = pressions(Y.Item1, Y.Item2, P.Item2);

        ButtonA.Intersect(ButtonB).ToList().ForEach(p =>
        {
          cost += tokens(p);

        });
      }
    }
  });
  Console.WriteLine($"cost {cost}");
}

void part2()
{
  double cost = 0;
  (double, double) X = (0, 0);
  (double, double) Y = (0, 0);
  (double, double) P = (0, 0);
  puzzle.ToList().ForEach(line =>
  {
    if (line.Trim() != "")
    {
      if (line.Contains("A:"))
      {
        var nums = mvt.Matches(line);
        X.Item1 = double.Parse(nums[0].Groups[1].Value);
        Y.Item1 = double.Parse(nums[1].Groups[2].Value);
      }
      if (line.Contains("B:"))
      {
        var nums = mvt.Matches(line);
        X.Item2 = double.Parse(nums[0].Groups[1].Value);
        Y.Item2 = double.Parse(nums[1].Groups[2].Value);
      }
      if (line.Contains("Prize:"))
      {
        var prizes = prz.Matches(line);
        P.Item1 = double.Parse(prizes[0].Groups[1].Value)+10000000000000;
        P.Item2 = double.Parse(prizes[1].Groups[2].Value)+10000000000000;
        
        double a = (P.Item1 * Y.Item2 - P.Item2 * X.Item2) / (X.Item1 * Y.Item2 - Y.Item1 * X.Item2);
        double b = (P.Item1 - X.Item1 * a) / X.Item2;
        Console.WriteLine($"ax: {X.Item1} ay: {Y.Item1} bx: {X.Item2} by: {Y.Item2} px: {P.Item1} py: {P.Item2} a {a} b {b}");
        if (a % 1 == 0 && b % 1 == 0) {
          
          cost += (double)(a * 3 + b);
        }
      }
    }
  });
  Console.WriteLine($"cost {cost}");
}

// part1();
part2();
