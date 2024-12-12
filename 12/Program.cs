using System.Data;
using System.Net;
using System.Net.Http.Headers;
using Microsoft.VisualBasic;

List<string> grid = File.ReadAllLines(@"C:\Users\yvesg\git\aoc2024\12\data.txt").ToList();
(int, int)[] directions = [(-1, 0), (1, 0), (0, -1), (0, 1)];

void part1()
{
  int height = grid.Count;
  int width = grid[0].Length;
  List<HashSet<(int, int)>> regions = [];
  HashSet<(int, int)> vus = new HashSet<(int, int)>();

  Enumerable.Range(0, height).ToList().ForEach(r =>
  {
    Enumerable.Range(0, width).ToList().ForEach(c =>
    {
      if (!vus.Contains((r, c)))
      {
        vus.Add((r, c));
        HashSet<(int, int)> region = [(r, c)];
        Queue<(int, int)> terrain = new Queue<(int, int)>();
        terrain.Enqueue((r, c));
        char plante = grid[r][c];
        while (terrain.Count > 0)
        {
          (int, int) spot = terrain.Dequeue();
          int y = spot.Item1;
          int x = spot.Item2;
          directions.ToList().ForEach(D =>
          {
            int yy = y + D.Item1;
            int xx = x + D.Item2;
            if (xx >= 0 && xx < width && yy >= 0 && yy < height)
            {
              if (grid[yy][xx] == plante)
              {
                if (!region.Contains((yy, xx)))
                {
                  region.Add((yy, xx));
                  vus.Add((yy, xx));
                  terrain.Enqueue((yy,xx));
                }
              }
            }
          });
        }
        regions.Add(region);
      }
    });
  });

  int total = 0;
  regions.ForEach(region =>
  {
    // Console.Write($"count : {region.Count} ");
    int perimetre = 0;
    region.ToList().ForEach(p =>
    {
      perimetre += 4;
      int r = p.Item1;
      int c = p.Item2;
      // Console.Write($"({r},{c}) ");
      directions.ToList().ForEach(D =>
      {
        int rr = r + D.Item1;
        int cc = c + D.Item2;
        if (region.Contains((rr,cc))) perimetre--;
      });
    });
    // Console.WriteLine($"Perimetre : {perimetre} ");
    total += perimetre * region.Count;
  });

  Console.WriteLine($"Total : {total}  ");

}

void part2()
{
int height = grid.Count;
  int width = grid[0].Length;
  List<HashSet<(int, int)>> regions = [];
  HashSet<(int, int)> vus = new HashSet<(int, int)>();

  Enumerable.Range(0, height).ToList().ForEach(r =>
  {
    Enumerable.Range(0, width).ToList().ForEach(c =>
    {
      if (!vus.Contains((r, c)))
      {
        vus.Add((r, c));
        HashSet<(int, int)> region = [(r, c)];
        Queue<(int, int)> terrain = new Queue<(int, int)>();
        terrain.Enqueue((r, c));
        char plante = grid[r][c];
        while (terrain.Count > 0)
        {
          (int, int) spot = terrain.Dequeue();
          int y = spot.Item1;
          int x = spot.Item2;
          directions.ToList().ForEach(D =>
          {
            int yy = y + D.Item1;
            int xx = x + D.Item2;
            if (xx >= 0 && xx < width && yy >= 0 && yy < height)
            {
              if (grid[yy][xx] == plante)
              {
                if (!region.Contains((yy, xx)))
                {
                  region.Add((yy, xx));
                  vus.Add((yy, xx));
                  terrain.Enqueue((yy,xx));
                }
              }
            }
          });
        }
        regions.Add(region);
      }
    });
  });
}

part1();
part2();
