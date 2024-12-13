using System.Text.RegularExpressions;

string[] puzzle = File.ReadAllLines(@"C:\Users\yvesg\git\aoc2024\13\data.txt");
string movement = @"X\+(\d*)|Y\+(\d*)";
Regex mvt = new Regex(movement);
string prize = @"X\=(\d*)|Y\=(\d*)";
Regex prz = new Regex(prize);

List<(int, int)> pressions(int x1, int x2, int target)
{
  int nb = 1;
  int nb2 = 1;
  int total = (x1 * nb + x2 * nb2);
  List<(int, int)> result = new List<(int, int)>();
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

int tokens((int, int) button)
{
  var (a, b) = button;
  return (a * 3 + b * 1);
}

void part1()
{
  int cost = 0;
  (int, int) X = (0, 0);
  (int, int) Y = (0, 0);
  (int, int) P = (0, 0);
  puzzle.ToList().ForEach(line =>
  {
    if (line.Trim() != "")
    {
      if (line.Contains("A:"))
      {
        var nums = mvt.Matches(line);
        X.Item1 = int.Parse(nums[0].Groups[1].Value);
        Y.Item1 = int.Parse(nums[1].Groups[2].Value);
      }
      if (line.Contains("B:"))
      {
        var nums = mvt.Matches(line);
        X.Item2 = int.Parse(nums[0].Groups[1].Value);
        Y.Item2 = int.Parse(nums[1].Groups[2].Value);
      }
      if (line.Contains("Prize:"))
      {
        var prizes = prz.Matches(line);
        P.Item1 = int.Parse(prizes[0].Groups[1].Value);
        P.Item2 = int.Parse(prizes[1].Groups[2].Value);
        var ButtonA = pressions(X.Item1,X.Item2,P.Item1);
        var ButtonB = pressions(Y.Item1,Y.Item2,P.Item2);

        ButtonA.Intersect(ButtonB).ToList().ForEach(p=>{
          cost += tokens(p);
          
        });
      }
    }
  });
Console.WriteLine($"cost {cost}");
}

void part2()
{

}

part1();
part2();
