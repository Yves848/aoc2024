
using System.Data;
using System.Runtime.InteropServices;

void part1()
{
  StreamReader sr = new StreamReader(@"C:\Users\yvesg\git\aoc2024\06\data.txt");
  List<string> grid = new List<string>();
  int x = 0, y = 0;
  while (!sr.EndOfStream)
  {
    string line = sr.ReadLine();
    if (line.IndexOf('^') > -1)
    {
      x = line.IndexOf('^');
      y = grid.Count();
    }
    grid.Add(line);
  }
  (int, int)[] directions = [(-1, 0), (0, 1), (1, 0), (0, -1)];
  int d = 0; // UP;
  int count = 1;
  while (true)
  {
    if ((y + directions[d].Item1) < 0 || (y + directions[d].Item1) >= grid.Count()) break;
    if ((x + directions[d].Item2) < 0 || (x + directions[d].Item2) >= grid[0].Length) break;
    y += directions[d].Item1;
    x += directions[d].Item2;
    if (grid[y][x] == '#')
    {
      y -= directions[d].Item1;
      x -= directions[d].Item2;
      d++;
      if (d >= directions.Length) { d = 0; }
    }
    else
    {
      if (grid[y][x] != 'X') count++;
      grid[y] = grid[y].Remove(x, 1).Insert(x, "X");
    }
  }
  Console.WriteLine($"Count : {count}");
}

void part2()
{
  StreamReader sr = new StreamReader(@"C:\Users\yvesg\git\aoc2024\06\data.txt");
  List<string> grid = new List<string>();
  int x = 0, y = 0;
  while (!sr.EndOfStream)
  {
    string line = sr.ReadLine();
    if (line.IndexOf('^') > -1)
    {
      x = line.IndexOf('^');
      y = grid.Count();
    }
    grid.Add(line);
  }
  int R = grid.Count;
  int C = grid[0].Length;
  (int, int)[] directions = [(-1, 0), (0, 1), (1, 0), (0, -1)];
  int d = 0; // UP;
  int p1 = 0;
  int p2 = 0;
  for (int o_r = 0; o_r < R; o_r++)
  {
    for (int o_c = 0; o_c < C; o_c++)
    {
      int r = y;
      int c = x;
      d = 0;
      List<(int, int, int)> SEEN = new List<(int, int, int)>();
      List<(int, int)> SEEN_RC = new List<(int, int)>();
      while (true)
      {
        if (SEEN.IndexOf((r, c, d)) > -1)
        {
          p2++;
          break;
        } else {
          SEEN.Add((r, c, d));
        }
        
        if (SEEN_RC.IndexOf((r,c)) == -1) {
          SEEN_RC.Add((r, c));
        }
        int dr = directions[d].Item1;
        int dc = directions[d].Item2;
        int rr = r + dr;
        int cc = c + dc;
        if (!((rr >= 0 && rr < R) && (cc >= 0 && cc < C)))
        {
          if (grid[o_r][o_c] == '#')
          {
            p1 = SEEN_RC.Count;
          }
          break;
        }
        if ((grid[rr][cc] == '#') || rr == o_r || cc == o_c)
        {
          d++;
          if (d >= directions.Length) { d = 0; }
        } else {
          r = rr;
          c = cc;
        }

      }
    }
  }
  Console.WriteLine($"p1 = {p1}");
  Console.WriteLine($"p2 = {p2}");
}

part1();
part2();