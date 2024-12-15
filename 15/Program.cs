using System.IO.Pipelines;

string input = "";
if (args.Length > 0)
{
  input = File.ReadAllText(args[0]);
}
else input = File.ReadAllText(@"C:\Users\yvesg\git\aoc2024\15\test3.txt");
var parts = input.Split("\r\n\r\n");

int gl = parts[0].Length;
List<string> grid = new List<string>();
(int, int) robot = (0, 0);

Dictionary<char, (int, int)> directions = new Dictionary<char, (int, int)>
{
    { '<', (-1, 0) },
    { '^', (0, -1) },
    { '>', (1, 0) },
    { 'v', (0, 1) }
};

void parseGrid()
{
  int r = 0;
  parts[0].Split("\r\n").ToList().ForEach(l =>
  {
    grid.Add(l);
    if (l.Contains('@'))
    {
      robot.Item1 = l.IndexOf('@');
      robot.Item2 = r;
    }
    r++;
  });
}

void parseGrid2()
{
  int r = 0;
  parts[0].Split("\r\n").ToList().ForEach(l =>
  {
    string line = "";
    l.ToList().ForEach(c =>
    {
      string ch = c.ToString();
      if (ch == "#" || ch == "O")
      {
        if (ch == "#")
        {
          line += "".PadLeft(2, '#');
        }
        else
        {
          line += "[]";
        }
      }
      else
      {
        if (ch == "@")
        {
          line += "@.";
        }
        else
        {
          line += "..";
        }
      }
    });
    grid.Add(line);
    if (line.Contains('@'))
    {
      robot.Item1 = line.IndexOf('@');
      robot.Item2 = r;
    }
    r++;
  });
}

void drawGrid()
{
  // Console.Clear();
  int row = 0;
  grid.ToList().ForEach(g =>
  {
    Console.WriteLine(g);
  });
}

void moveRobot(char direction)
{
  if (directions.ContainsKey(direction))
  {
    // direction to move
    var (dc, dr) = directions[direction];
    // robot position
    var (rc, rr) = robot;
    while (true)
    {
      // check next spot
      int nc = rc + dc;
      int nr = rr + dr;
      if (nr > grid.Count - 1 || nr < 0 || nc > grid[0].Length - 1 || nc < 0) break;
      string target = grid[nr].Substring(nc, 1);
      if (target == "#") break;
      if (target == ".")
      {
        // free spot, move robot
        grid[rr] = grid[rr].Remove(rc, 1).Insert(rc, ".");
        grid[nr] = grid[nr].Remove(nc, 1).Insert(nc, "@");
        robot.Item1 = nc;
        robot.Item2 = nr;
        break;
      }
      if (target == "O")
      {
        // deterine if there is room to move while queuing the crates.
        HashSet<(int, int)> crates = [(nr, nc)];
        bool room = false; // first free spot to check
        int fr = nr, fc = nc;
        while (true)
        {
          fr += dr;
          fc += dc;
          if (fr > grid.Count - 1 || fr < 0 || fc > grid[0].Length - 1 || fc < 0) break;
          string free = grid[fr].Substring(fc, 1);
          if (free == "O")
          {
            crates.Add((fr, fc));
          }
          if (free == ".")
          {
            room = true;
            break;
          }
          if (free == "#")
          {
            break;
          }
        }
        if (room)
        {
          crates.ToList().ForEach(crate =>
          {
            var (r, c) = crate;
            grid[r] = grid[r].Remove(c, 1).Insert(c, ".");
          });
          crates.ToList().ForEach(crate =>
          {
            var (r, c) = crate;
            grid[r + dr] = grid[r + dr].Remove(c + dc, 1).Insert(c + dc, "O");
          });
          grid[rr] = grid[rr].Remove(rc, 1).Insert(rc, ".");
          grid[nr] = grid[nr].Remove(nc, 1).Insert(nc, "@");
          robot.Item1 = nc;
          robot.Item2 = nr;
        }

        break;
      }
      break;
    }
    // drawGrid();
    // Console.WriteLine($"direction {direction}");
    // Console.ReadLine();
  }
}

void moveRobot2(char direction)
{
  if (directions.ContainsKey(direction))
  {
    // direction to move
    var (dc, dr) = directions[direction];
    // robot position
    var (rc, rr) = robot;
    while (true)
    {
      // check next spot
      if (direction == '<' || direction == '>')
      {
        int nc = rc + dc;
        int nr = rr + dr;
        if (nr > grid.Count - 1 || nr < 0 || nc > grid[0].Length - 1 || nc < 0) break;
        string target = grid[nr].Substring(nc, 1);
        if (target == "#") break;
        if (target == ".")
        {
          // free spot, move robot
          grid[rr] = grid[rr].Remove(rc, 1).Insert(rc, ".");
          grid[nr] = grid[nr].Remove(nc, 1).Insert(nc, "@");
          robot.Item1 = nc;
          robot.Item2 = nr;
          break;
        }
        if ("[]".Contains(target))
        {
          // deterine if there is room to move while queuing the crates.
          HashSet<(int, int, string)> crates = [(nr, nc, target)];
          bool room = false; // first free spot to check
          int fr = nr, fc = nc;
          while (true)
          {
            fr += dr;
            fc += dc;
            if (fr > grid.Count - 1 || fr < 0 || fc > grid[0].Length - 1 || fc < 0) break;
            string free = grid[fr].Substring(fc, 1);
            if ("[]".Contains(free))
            {
              crates.Add((fr, fc, free));
            }
            if (free == ".")
            {
              room = true;
              break;
            }
            if (free == "#")
            {
              break;
            }
          }
          if (room)
          {
            crates.ToList().ForEach(crate =>
            {
              var (r, c, _) = crate;
              grid[r] = grid[r].Remove(c, 1).Insert(c, ".");
            });
            crates.ToList().ForEach(crate =>
            {
              var (r, c, ch) = crate;
              grid[r + dr] = grid[r + dr].Remove(c + dc, 1).Insert(c + dc, ch);
            });
            grid[rr] = grid[rr].Remove(rc, 1).Insert(rc, ".");
            grid[nr] = grid[nr].Remove(nc, 1).Insert(nc, "@");
            robot.Item1 = nc;
            robot.Item2 = nr;
          }

          break;
        }
        break;        // horizontal
      }
      else
      {
        int nc = rc + dc;
        int nr = rr + dr;
        if (nr > grid.Count - 1 || nr < 0 || nc > grid[0].Length - 1 || nc < 0) break;
        string target = grid[nr].Substring(nc, 1);
        if (target == "#") break;
        if (target == ".")
        {
          // free spot, move robot
          grid[rr] = grid[rr].Remove(rc, 1).Insert(rc, ".");
          grid[nr] = grid[nr].Remove(nc, 1).Insert(nc, "@");
          robot.Item1 = nc;
          robot.Item2 = nr;
          break;
        }
        break;
      }
    }
    drawGrid();
    Console.WriteLine($"direction {direction}");
    Console.ReadLine();
  }
}

int getGPS()
{
  int result = 0;
  for (int row = 1; row < grid.Count - 1; row++)
  {
    int col = 0;
    while (true)
    {
      col = grid[row].IndexOf("O", col + 1);
      if (col == -1) break;
      result += row * 100 + col;
    }
  }
  return result;
}

void part1()
{
  parseGrid();
  parts[1].Trim().ToList().ForEach(moveRobot);
  drawGrid();
  int gps = getGPS();
  Console.WriteLine($"total = {gps}");
}

void part2()
{
  parseGrid2();
  drawGrid();
  parts[1].Trim().ToList().ForEach(moveRobot2);
}

// part1();
part2();

