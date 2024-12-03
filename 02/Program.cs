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
  foreach (var line in lines)
  {

    string[] parts = line.Split(" ");
    int i = 0;
    int direction = 0;
    int i2 = 1;
    bool valid = true;
    bool damp = false;
    while (i < parts.Length - 1)
    {
      i2 = i + 1;
      int diff = Math.Abs(Convert.ToInt32(parts[i]) - Convert.ToInt32(parts[i2]));
      if ((diff < 1) || (diff > 3))
      {
        valid = false;
        if (!damp && i2 < parts.Length - 1)
        {
          diff = Math.Abs(Convert.ToInt32(parts[i]) - Convert.ToInt32(parts[i2 + 1]));
          if (diff >= 1 && (diff <= 3))
          {
            valid = true;
            damp = true;
          }
        }
      }
      Console.WriteLine($"{valid} {diff} - {parts[i]} {parts[i2]} {damp} : " + line);
      if (valid)
      {
        if (direction == 0)
        {
          direction = Convert.ToInt32(parts[i]) <= Convert.ToInt32(parts[i2]) ? 1 : -1;
        }
        else
        {
          if ((Convert.ToInt32(parts[i]) <= Convert.ToInt32(parts[i2]) ? 1 : -1) != direction)
          {
            valid = false;
            Console.WriteLine($"Invalid: direction - {damp} " + line);
            // i2++;
          }
          else
          {
            if ((i2 < parts.Length - 1) && !damp)
            {
              if ((Convert.ToInt32(parts[i]) <= Convert.ToInt32(parts[i2 + 1]) ? 1 : -1) == direction)
              {
                valid = true;
                damp = true;
                Console.WriteLine($"valid: direction - {damp} " + line);
              }
              else
              {
                valid = false;
                Console.WriteLine($"Invalid: direction - {damp} " + line);
              }
            }
          }
        }
      }
        // i++;
        if (damp) { i += 2; }
        else { i++; }
      }
      if (valid)
      {
        Console.WriteLine($"valid: " + line);
        count++;
      }
      else {
        Console.WriteLine($"Invalid {line}");
      }
    }
    Console.WriteLine(count);
  }

  sr.Close();

  // part1();
  part2();