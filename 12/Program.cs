using System.Diagnostics;

List<string> grid = File.ReadAllLines(@"C:\Users\yvesg\git\aoc2024\12\data.txt").ToList();
(int, int)[] directions = [(-1, 0), (1, 0), (0, -1), (0, 1)];
int height = grid.Count;
int width = grid[0].Length;
List<HashSet<(float, float)>> regions = [];
HashSet<(float, float)> vus = new HashSet<(float, float)>();

Enumerable.Range(0, height).ToList().ForEach(r =>
{
  Enumerable.Range(0, width).ToList().ForEach(c =>
  {
    if (!vus.Contains((r, c)))
    {
      vus.Add((r, c));
      HashSet<(float, float)> region = [(r, c)];
      Queue<(float, float)> terrain = new Queue<(float, float)>();
      terrain.Enqueue((r, c));
      char plante = grid[r][c];
      while (terrain.Count > 0)
      {
        // (int, int) spot = terrain.Dequeue();
        // int y = spot.Item1;
        // int x = spot.Item2;
        var (y, x) = terrain.Dequeue();
        directions.ToList().ForEach(D =>
        {
          float yy = y + D.Item1;
          float xx = x + D.Item2;
          if (xx >= 0 && xx < width && yy >= 0 && yy < height)
          {
            if (grid[(int)yy][(int)xx] == plante)
            {
              if (!region.Contains((yy, xx)))
              {
                region.Add((yy, xx));
                vus.Add((yy, xx));
                terrain.Enqueue((yy, xx));
              }
            }
          }
        });
      }
      regions.Add(region);
    }
  });
});

void part1()
{
  int total = 0;
  regions.ForEach(region =>
  {
    int perimetre = 0;
    region.ToList().ForEach(p =>
    {
      perimetre += 4;
      // int r = p.Item1;
      // int c = p.Item2;
      var (r, c) = p;
      directions.ToList().ForEach(D =>
      {
        float rr = r + D.Item1;
        float cc = c + D.Item2;
        if (region.Contains((rr, cc))) perimetre--;
      });
    });
    total += perimetre * region.Count;
  });

  Console.WriteLine($"Part1 - Total : {total}  ");

}

void part2()
{
  int total = 0;
  regions.ToList().ForEach(region =>
  {
    Dictionary<(float, float), (float, float)> bords = new Dictionary<(float, float), (float, float)>();
    region.ToList().ForEach(p =>
    {
      var (r, c) = p;
      directions.ToList().ForEach(d =>
      {
        var (dr, dc) = d;
        float rr = r + dr;
        float cc = c + dc;
        if (!region.Contains((rr, cc)))
        {
          float er = (r + rr) / 2;
          float ec = (c + cc) / 2;
          bords.Add((er, ec), (er - r, ec - c));
        }
      });
    });
    int cotes = 0;
    vus.Clear();
    bords.ToList().ForEach(p =>
    {
      var (bord, direction) = p;
      if (!vus.Contains(bord))
      {
        vus.Add(bord);
        cotes++;
        var (er, ec) = bord;
        if (er % 1 == 0)
        {
          foreach (float dr in new[] { -1, 1 })
          { 
            var cr = er + dr;
            (float, float) d2;
            while(bords.TryGetValue((cr,ec),out d2)) {
              if (d2 != direction) break;
              vus.Add((cr,ec));
              cr += dr;
            }
          }
        } else {
          foreach (float dc in new[] { -1, 1 })
          { 
            var cc = ec + dc;
            (float,float) d2;
            while (bords.TryGetValue((er,cc), out d2)) {
              if (d2 != direction) break;
              vus.Add((er,cc));
              cc += dc;
            }
          }
        }
      }
    });
    total += cotes * region.Count;;
  });
  Console.WriteLine($"Part2 - Total : {total}  ");
}

Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();
part1();
stopwatch.Stop();
TimeSpan ts = stopwatch.Elapsed;
string elapsed = String.Format("{0:000} ms", ts.Milliseconds);
Console.WriteLine("Temps : " + elapsed);


stopwatch = new Stopwatch();
stopwatch.Start();
part2();
stopwatch.Stop();
ts = stopwatch.Elapsed;
elapsed = String.Format("{0:000} ms", ts.Milliseconds);
Console.WriteLine("Temps : " + elapsed);
