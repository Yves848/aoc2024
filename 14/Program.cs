using System.Diagnostics.CodeAnalysis;
using System.IO.Pipelines;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

var input = File.ReadAllLines(@"C:\Users\yvesg\git\aoc2024\14\data.txt");
string pattern = @"p\=(\d*),(\d*)|v\=(-?\d+),(-?\d+)";
Regex reVal = new Regex(pattern);
int width = 101, height = 103;
(int, int, int, int)[] robots = new (int, int, int, int)[input.Length];
int i = 0;
input.ToList().ForEach(l =>
{
  var s = l.Split(' ');
  var p = s[0].Substring(2).Split(',');
  var v = s[1].Substring(2).Split(',');
  // Console.WriteLine($"p {p[0]},{p[1]} v {v[0]},{v[1]}");
  robots[i] = (int.Parse(p[0]), int.Parse(p[1]), int.Parse(v[0]), int.Parse(v[1]));
  i++;
});
Dictionary<int, int> quadrants = new Dictionary<int, int>();

void move(int robot)
{
  var (x, y, vx, vy) = robots[robot];
  x += vx;
  if (x < 0)
  {
    x = width - Math.Abs(x);
  }
  if (x > width - 1)
  {
    x -= width;
  }
  y += vy;
  if (y < 0)
  {
    y = height - Math.Abs(y);
  }
  if (y > height - 1)
  {
    y -= height;
  }
  robots[robot].Item1 = x;
  robots[robot].Item2 = y;
}

void drawGrid(int mvt)
{
  Console.Clear();
  string[] grid = new string[height];
  for (i = 0; i < grid.Length; i++)
  {
    grid[i] = "".PadLeft(width, '.');
  };
  robots.ToList().ForEach(robot =>
  {
    int count = 0;
    var (x, y, _, _) = robot;
    if (int.TryParse(grid[y][x].ToString(), out count))
    {
      grid[y] = grid[y].Remove(x, 1).Insert(x, (++count).ToString());
    }
    else
    {
      grid[y] = grid[y].Remove(x, 1).Insert(x, "1");
    }
  });

  grid.ToList().ForEach(l => Console.WriteLine(l));
  Console.WriteLine(mvt);
  Console.ReadLine();
  Thread.Sleep(50);
}

void part1()
{
  int mvt = 100;
  while (mvt > 0)
  {
    for (int i = 0; i < robots.Length; i++)
    {
      move(i);
    }
    mvt--;
    // drawGrid(mvt);
  }

  var q1 = robots.ToList().Where(robot =>
  {
    var (x, y, _, _) = robot;
    return x >= 0 && x < (width - 1) / 2 && y >= 0 && y < (height - 1) / 2;

  }).Count();
  var q2 = robots.ToList().Where(robot =>
  {
    var (x, y, _, _) = robot;
    return x > (width - 1) / 2 && x <= width - 1 && y >= 0 && y < (height - 1) / 2;

  }).Count();
  var q3 = robots.ToList().Where(robot =>
  {
    var (x, y, _, _) = robot;
    return x >= 0 && x < (width - 1) / 2 && y > (height - 1) / 2 && y <= height - 1;

  }).Count();
  var q4 = robots.ToList().Where(robot =>
  {
    var (x, y, _, _) = robot;
    return x > (width - 1) / 2 && x <= width - 1 && y > (height - 1) / 2 && y <= height - 1;

  }).Count();
  Console.WriteLine($"Q1 : {q1} Q2 : {q2} Q3 : {q3} Q4 : {q4}");
  Console.WriteLine($"Total : {q1 * q2 * q3 * q4}");

}

void part2()
{
  int mvt = 0;
  int min_sf = int.MaxValue;
  int best = 0;
  while (mvt < (width * height))
  {
    for (int i = 0; i < robots.Length; i++)
    {
      move(i);
    }
    // mvt++;
    // drawGrid(mvt);


    var q1 = robots.ToList().Where(robot =>
    {
      var (x, y, _, _) = robot;
      return x >= 0 && x < (width - 1) / 2 && y >= 0 && y < (height - 1) / 2;

    }).Count();
    var q2 = robots.ToList().Where(robot =>
    {
      var (x, y, _, _) = robot;
      return x > (width - 1) / 2 && x <= width - 1 && y >= 0 && y < (height - 1) / 2;

    }).Count();
    var q3 = robots.ToList().Where(robot =>
    {
      var (x, y, _, _) = robot;
      return x >= 0 && x < (width - 1) / 2 && y > (height - 1) / 2 && y <= height - 1;

    }).Count();
    var q4 = robots.ToList().Where(robot =>
    {
      var (x, y, _, _) = robot;
      return x > (width - 1) / 2 && x <= width - 1 && y > (height - 1) / 2 && y <= height - 1;

    }).Count();
    // Console.WriteLine($"Q1 : {q1} Q2 : {q2} Q3 : {q3} Q4 : {q4}");
    // Console.WriteLine($"Total : {q1 * q2 * q3 * q4}");
    if (q1 * q2 * q3 * q4 < min_sf)
    {
      min_sf = q1 * q2 * q3 * q4;
      best = mvt;
      drawGrid(mvt);
    }
    mvt++;
  }
  Console.WriteLine($"min_sf {min_sf} best {best}");
}

part1();

part2();