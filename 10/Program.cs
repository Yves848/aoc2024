string[] data = File.ReadAllText(@"C:\Users\yvesg\git\aoc2024\10\data.txt").Split("\r\n");
(int, int)[] directions = [(-1, 0), (0, 1), (1, 0), (0, -1)];

void part1()
{

  int L = data[0].Length;
  int H = data.Length;
  int findPath((int, int) pos)
  {
    HashSet<(int, int)> path = new HashSet<(int, int)>();
    HashSet<(int, int)> deja = new HashSet<(int, int)>();
    path.Add(pos);
    int total = 0;
    int r = 0;
    int c = 0;
    while (path.Count > 0)
    {
      var p = path.First();
      r = p.Item1;
      c = p.Item2;
      path.Remove(p);
      if (deja.Contains(p)) continue;
      deja.Add(p);
      if (int.Parse(data[r][c].ToString()) == 9)
      {
        total++;
      }
      foreach ((int, int) p1 in directions)
      {
        int dr = p1.Item1;
        int dc = p1.Item2;
        int rr = r + dr;
        int cc = c + dc;
        if (0 <= rr && rr < H && 0 <= cc && cc < L)
        {
          if (int.Parse(data[rr][cc].ToString()) == int.Parse(data[r][c].ToString()) + 1)
          {
            path.Add((rr, cc));
          }
        }
      }
    }

    return total;
  }

  int total = 0;
  for (int r = 0; r < H; r++)
  {
    for (int c = 0; c < L; c++)
    {
      if (data[r][c] == '0')
      {
        total += findPath((r, c));
      }
    }
  }

  Console.WriteLine(total);

}

void part2()
{

  int L = data[0].Length;
  int H = data.Length;
  Dictionary<(int, int), int> distincts = new Dictionary<(int, int), int>();
  int findPath((int, int) pos)
  {
    int total = 0;
    int r = pos.Item1;
    int c = pos.Item2;
    if (int.Parse(data[r][c].ToString()) == 9) return 1;
    if (distincts.ContainsKey((r, c)))
    {
      return distincts[(r, c)];
    }

    foreach ((int, int) p1 in directions)
    {
      int dr = p1.Item1;
      int dc = p1.Item2;
      int rr = r + dr;
      int cc = c + dc;
      if (0 <= rr && rr < H && 0 <= cc && cc < L)
      {
        if (int.Parse(data[rr][cc].ToString()) == int.Parse(data[r][c].ToString()) + 1)
        {
          total += findPath((rr, cc));
        }
      }
    }
    distincts[(r,c)] = total;
    return total;
  }

  int total = 0;
  for (int r = 0; r < H; r++)
  {
    for (int c = 0; c < L; c++)
    {
      if (data[r][c] == '0')
      {
        total += findPath((r, c));
      }
    }
  }

  Console.WriteLine(total);

}

part1();
part2();