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
    bool damp = false;
    bool valide = true;
    int direction = 0;
    foreach(int n in nums) {
      Console.Write($"{n} ");
    }
    Console.WriteLine();
    while (i < nums.Count - 1)
    {
      int i2 = i + 1;
      int diff = Math.Abs(nums[i] - nums[i2]);
      if (diff < 1 || diff > 3)
      {
        valide = false;
        if (!damp && i2 < nums.Count - 1)
        {
          diff = Math.Abs(nums[i] - nums[i2 + 1]);
          if (diff >= 1 && diff <= 3)
          {
            valide = true;
            damp = true;
            nums.RemoveAt(i2);
          }
        }
      }
      if (valide)
      {
        if (direction == 0)
        {
          direction = (nums[i] <= nums[i2]) ? 1 : -1;
        }
        else
        {
          if (((nums[i] <= nums[i2]) ? 1 : -1) == direction) {
            valide = true;
          } else {
            if (!damp && i2 < nums.Count - 1) {
              if (((nums[i] <= nums[i2+1]) ? 1 : -1) == direction) {
                damp = true;
                valide = true;
                nums.RemoveAt(i2);
              } else {
                valide = false;
              }
            } else {
              valide = false;
            }
          }
        }
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