


using System.Diagnostics;

void part1()
{
  StreamReader sr = new StreamReader(@"C:\Users\yvesg\git\aoc2024\05\data.txt");
  List<string> rules = new List<string>();
  List<string> updates = new List<string>();
  while (!sr.EndOfStream)
  {
    string? line = sr.ReadLine();
    if (line.Contains('|'))
    {
      rules.Add(line);
    }
    if (line.Contains(','))
    {
      updates.Add(line);
    }
  }
  sr.Close();
  int count = 0;
  foreach (string line in updates)
  {
    List<string> pages = line.Split(',').ToList();
    bool valid = true;
    foreach (string page in pages)
    {
      int reference = pages.IndexOf(page);
      List<string> valids = rules.Where(rule => rule.Contains(page)).ToList();
      foreach (string tuple in valids)
      {
        int direction = -1;
        string[] limits = tuple.Split('|');
        string limit = limits[0];
        if (limits[0] == page)
        {
          limit = limits[1];
          direction = 1;
        }
        int pos = pages.IndexOf(limit);
        valid = (direction == -1 && reference == 0) || (direction == -1 && pos < reference) || (direction == 1 && pos > reference) || (pos == -1);
        if (!valid) break;
      }
      if (!valid) {
        break;
      }
    }
    if (valid)
    {
      int middle = (int)(Math.Round((decimal)(pages.Count / 2)));
      Console.WriteLine(line);
      count += int.Parse(pages[middle]);
    }
    // Console.WriteLine();
  }
  Console.WriteLine(count);
}

string order(List<string> tuples) {
  string result = "";
  return "";
}

void part2()
{
  StreamReader sr = new StreamReader(@"C:\Users\yvesg\git\aoc2024\05\data.txt");
  List<string> rules = new List<string>();
  List<string> updates = new List<string>();
  while (!sr.EndOfStream)
  {
    string? line = sr.ReadLine();
    if (line.Contains('|'))
    {
      rules.Add(line);
    }
    if (line.Contains(','))
    {
      updates.Add(line);
    }
  }
  sr.Close();
  int count = 0;
  foreach (string line in updates)
  {
    List<string> pages = line.Split(',').ToList();
    bool valid = true;
    foreach (string page in pages)
    {
      int reference = pages.IndexOf(page);
      List<string> valids = rules.Where(rule => rule.Contains(page)).ToList();
      foreach (string tuple in valids)
      {
        int direction = -1;
        string[] limits = tuple.Split('|');
        string limit = limits[0];
        if (limits[0] == page)
        {
          limit = limits[1];
          direction = 1;
        }
        int pos = pages.IndexOf(limit);
        valid = (direction == -1 && reference == 0) || (direction == -1 && pos < reference) || (direction == 1 && pos > reference) || (pos == -1);
        if (!valid) break;
      }
      if (!valid) break;
    }
    if (valid)
    {
      int middle = (int)(Math.Round((decimal)(pages.Count / 2)));
      Console.WriteLine(line);
      count += int.Parse(pages[middle]);
    }
    // Console.WriteLine();
  }
  Console.WriteLine(count);
}

part1();
part2();
