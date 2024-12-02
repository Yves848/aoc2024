StreamReader sr = new StreamReader("test.txt");
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
    bool damp = false;
    while (i < parts.Length - 1)
    {
      i2 = i + 1;
      valid = true;
      int diff = Math.Abs(Convert.ToInt32(parts[i]) - Convert.ToInt32(parts[i2]));
      if ((diff >= 1) && (diff <= 3))
      {
        valid = true;
        Console.WriteLine($"Valid {diff} - {parts[i]} {parts[i2]} {damp} : " + line);
        // i2++;
      }
      else
      {
        if ((i2 < parts.Length - 1) && !damp)
        {
          diff = Math.Abs(Convert.ToInt32(parts[i]) - Convert.ToInt32(parts[i2 + 1]));
          if ((diff >= 1) && (diff <= 3))
          {
            valid = true;
            damp = true;
            Console.WriteLine($"Valid {diff} - {parts[i]} {parts[i2 + 1]} {damp} : " + line);
          }
          else
          {
            valid = false;
          }
        }
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
            Console.WriteLine($"Invalid: direction - {damp} " + line);
            // i2++;
          }
          else
          {
            if ((i2 < parts.Length - 1) && !damp)
            {
              if ((Convert.ToInt32(parts[i]) < Convert.ToInt32(parts[i2 + 1]) ? 1 : -1) == direction)
              {
                valid = true;
                damp = true;
                Console.WriteLine($"valid: direction - {damp} " + line);
                // i2++;
              }
              else { valid = false; }
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
  }
  Console.WriteLine(count);
}

sr.Close();

part1();