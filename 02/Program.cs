using System.Text.RegularExpressions;

StreamReader sr = new StreamReader("data.txt");
string text = sr.ReadToEnd();
string[] lines = text.Split("\r\n");

void part1()
{
  int count = 0;
  foreach (var line in lines)
  {

    string[] parts = line.Split(" ");
    int i = 0;
    int direction = 0;
    int i2 = 1;
    bool valid = true;
    while (i < parts.Length - 2)
    {
      i2 = i + 1;
      int diff = Math.Abs(Convert.ToInt32(parts[i]) - Convert.ToInt32(parts[i2]));
      if ((diff < 1) || (diff > 3))
      {
        valid = false;
        Console.WriteLine($"InvalidValid {diff} - {parts[i]} {parts[i2]} : " + line);
        // i2++;
      }
      if (valid)
      {
        if (direction == 0)
        {
          direction = Convert.ToInt32(parts[i]) < Convert.ToInt32(parts[i2]) ? 1 : -1;
        }
        else
        {
          if ((Convert.ToInt32(parts[i]) < Convert.ToInt32(parts[i2]) ? 1 : -1) != direction)
          {
            valid = false;
            Console.WriteLine($"Invalid: direction - " + line);
            // i2++;
          }
        }
      }
      i++;
    }

    if (valid)
    {
      // Console.WriteLine($"valid: " + line);
      count++;
    }
  }
  Console.WriteLine(count);
}

int isSorted(List<int> list)
{
  bool sorted = false;
  int direction = 0;
  int i = 0; 
  while (i < list.Count-1) {
    if (list[i] == list[i+1]) {
      sorted = false;
      break;
    }
    if (direction == 0) {
      direction = (list[i] < list[i+1]) ? -1 : 1;
    } else {
      int direction2 = (list[i] < list[i+1]) ? -1 : 1;
      sorted = direction2 == direction;
      if (!sorted) break;
    }
    int delta = Math.Abs(list[i] - list[i+1]);
    if (delta < 1 || delta > 3) {
      i++;
      sorted = false;
      break; 
    }
    i++;
  }
  if (sorted) {i=-1;}
  return i;
}



void part2()
{
  int count = 0;
  string pattern = @"\d{1,}";
  Regex renums = new Regex(pattern);

  foreach (var line in lines)
  {
    MatchCollection matches = renums.Matches(line);
    List<int> nums = new List<int>();
    foreach (Match match in matches)
    {
      nums.Add(int.Parse(match.Value));
    }
    int i = 0;
    bool valide = true;
    foreach(int n in nums) {
      Console.Write($"{n} ");
    }
    Console.WriteLine();
    while (i < nums.Count - 1)
    {
      int i2 = isSorted(nums);
      if (i2 > -1) {
        nums.RemoveAt(i2);
        i2 = isSorted(nums);
        valide = (i2 == -1);
        if (!valide) break;
      }
      i++;
    }
    foreach(int n in nums) {
      Console.Write($"{n} ");
    }
    Console.WriteLine(valide);
    if (valide) {
      count++;
    }
  }

  Console.WriteLine(count);
}

sr.Close();

// part1();
part2();