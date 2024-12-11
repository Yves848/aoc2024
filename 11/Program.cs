using System.IO.Pipelines;
using System.Reflection.Metadata.Ecma335;

void part1()
{
  List<ulong> data = File.ReadAllText(@"C:\Users\yvesg\git\aoc2024\11\data.txt").Split(' ').ToList().Select(p => ulong.Parse(p)).ToList();
  ulong total = 0;
  data.ForEach(d =>
  {
    int rev = 0;
    List<ulong> numbers = new List<ulong>();
    numbers.Add(d);
    // Console.WriteLine(d);
    while (rev < 25)
    {
      List<ulong> temp = new List<ulong>();
      int i = 0;
      // numbers.ForEach(n => Console.WriteLine(n));
      while (i < numbers.Count)

      {
        // rule 1
        if (numbers[i] == 0)
        {
          temp.Add(1);
          i++;
          continue;
        }
        // rule 2
        string number = numbers[i].ToString();
        if (number.Length % 2 == 0 && number.Length > 1)
        {
          temp.Add(ulong.Parse(number.Substring(0, (number.Length / 2))));
          temp.Add(ulong.Parse(number.Substring((number.Length / 2))));
          i++;
          continue;
        }
        // rule 3
        temp.Add(numbers[i] * 2024);

        i++;
      }
      numbers = temp;
      rev++;
    }
    total += (ulong)numbers.Count;
  });

  // numbers.ForEach(n => Console.WriteLine(n));
  Console.WriteLine(total);
}

Dictionary<(ulong, int), ulong> Sol = new Dictionary<(ulong, int), ulong>();
ulong stones(ulong stone, int num)
{
  if (Sol.ContainsKey((stone, num))) return Sol[(stone, num)];
  if (num == 0) return 1;
  ulong result = 0;
  if (stone == 0)
  {
    result = stones(1, num - 1);
    Sol[(stone, num)] = result;
    return result;
  }
  string number = stone.ToString();
  if (number.Length > 1 && number.Length % 2 == 0)
  {
    ulong stone1 = ulong.Parse(number.Substring(0, (number.Length / 2)));
    ulong stone2 = ulong.Parse(number.Substring((number.Length / 2)));
    result = stones(stone1, num - 1) + stones(stone2, num - 1);
    Sol[(stone, num)] = result;
    return result;
  }
  result = stones(stone * 2024, num - 1);
  Sol[(stone, num)] = result;
  return result;
}

void part2()
{
  // peut aussi servir pour partie 1
  List<ulong> data = File.ReadAllText(@"C:\Users\yvesg\git\aoc2024\11\data.txt").Split(' ').ToList().Select(p => ulong.Parse(p)).ToList();
  ulong total = 0;
  Sol.Clear();
  data.ForEach(d =>
  {
    total += stones(d, 75);
  });
  Console.WriteLine(total);
}




part1();
part2();