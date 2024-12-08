void part1()
{
  Int64 total = 0;

  bool CanObtain(long target, List<int> array)
  {
    if (array.Count == 1) return target == array[0];
    // Check divisibility and recursive call
    if (target % array[^1] == 0 && CanObtain(target / array[^1], array.Take(array.Count - 1).ToList()))
    {
      return true;
    }

    // Check subtraction and recursive call
    if (target > array[^1] && CanObtain(target - array[^1], array.Take(array.Count - 1).ToList()))
    {
      return true;
    }

    return false;
  }



  foreach (var line in File.ReadAllText(@"C:\Users\yvesg\git\aoc2024\07\data.txt").Split(['\n'], StringSplitOptions.RemoveEmptyEntries))
  {
    var parts = line.Split(": ");
    long target = long.Parse(parts[0]);
    List<int> array = parts[1].Split(' ').Select(int.Parse).ToList();

    if (CanObtain(target, array))
    {
      total += target;
    }
  }

  Console.WriteLine(total);
}

void part2()
{
  Int64 total = 0;

  bool CanObtain(long target, List<int> array)
  {
    if (array.Count == 1)
      return target == array[0];

    // Check divisibility
    if (target % array[^1] == 0 && CanObtain(target / array[^1], array.Take(array.Count - 1).ToList()))
      return true;

    // Check subtraction
    if (target > array[^1] && CanObtain(target - array[^1], array.Take(array.Count - 1).ToList()))
      return true;

    // Check string ending condition
    string sTarget = target.ToString();
    string sLast = array[^1].ToString();

    if (sTarget.EndsWith(sLast) && sTarget.Length > sLast.Length)
    {
      long newTarget = long.Parse(sTarget.Substring(0, sTarget.Length - sLast.Length));
      if (CanObtain(newTarget, array.Take(array.Count - 1).ToList()))
        return true;
    }

    return false;
  }



  foreach (var line in File.ReadAllText(@"C:\Users\yvesg\git\aoc2024\07\data.txt").Split(['\n'], StringSplitOptions.RemoveEmptyEntries))
  {
    var parts = line.Split(": ");
    long target = long.Parse(parts[0]);
    List<int> array = parts[1].Split(' ').Select(int.Parse).ToList();

    if (CanObtain(target, array))
    {
      total += target;
    }
  }

  Console.WriteLine(total);
}

part1();
part2();