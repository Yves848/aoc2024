using System.ComponentModel;
using System.Text.RegularExpressions;



void part1()
{
  StreamReader sr = new StreamReader("data.txt");
  string mul = @"mul\(\d{1,},\d{1,}\)";
  string valeurs = @"\d{1,}";

  Regex reMul = new Regex(mul);
  Regex reValeurs = new Regex(valeurs);
  int total = 0;
  while (!sr.EndOfStream)
  {
    string? line = sr.ReadLine();
    MatchCollection matches = reMul.Matches(line);

    foreach (Match match in matches)
    {
      Console.WriteLine(match.Value);
      MatchCollection val = reValeurs.Matches(match.Value);
      Console.WriteLine($"{val[0].Value} * {val[1].Value}");
      total += int.Parse(val[0].Value) * int.Parse(val[1].Value);
    }
  }
  Console.WriteLine($"Total: {total}");
  sr.Close();
}

void part2()
{
  StreamReader sr = new StreamReader("data.txt");
  string rep = @"don't\(\)|do\(\)";
  string mul = @"mul\(\d{1,},\d{1,}\)";
  string valeurs = @"\d{1,}";

  Regex reMul = new Regex(mul);
  Regex reValeurs = new Regex(valeurs);
  Regex reReplace = new Regex(rep);
  string text = sr.ReadToEnd();
  string lines = text.Replace("\r\n", "");
  // Console.WriteLine($"Total: {lines}");
  MatchCollection matches = reReplace.Matches(lines);
  int index = 0;
  int lenght = 0;
  string oldmatch = "do()";
  int i = 0;
  while (i < matches.Count)
  {
    // Console.WriteLine(matches[i].Value);
    if (matches[i].Value == "don't()")
    {
      if (oldmatch == "do()")
      {
        oldmatch = matches[i].Value;
        index = matches[i].Index;
      }
    }
    else
    {
      try
      {
        if (oldmatch == "don't()")
        {
          lenght = matches[i].Index - index;
          lines = lines.Remove(index, lenght).Insert(index, "#".PadLeft(lenght, '#'));
          oldmatch = matches[i].Value;
        }
      }
      catch (Exception e)
      {
        Console.WriteLine($"Error: {e.Message}");
      }
    }
    i++;
  }
  int total = 0;
  MatchCollection matches2 = reMul.Matches(lines);
  foreach (Match match in matches2)
  {
    Console.WriteLine(match.Value);
    MatchCollection val = reValeurs.Matches(match.Value);
    Console.WriteLine($"{val[0].Value} * {val[1].Value}");
    total += int.Parse(val[0].Value) * int.Parse(val[1].Value);
  }
  Console.WriteLine($"Total: {total}");
  sr.Close();
}

part1();
part2();
