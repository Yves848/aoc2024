using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


// Read grid from standard input
void part1()
{
  List<string> grid = File.ReadAllText(@"C:\Users\yvesg\git\aoc2024\08\data.txt")
                              .Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
                              .Select(line => line.Trim())
                              .ToList();

  int rows = grid.Count;
  int cols = grid[0].Length;

  // Store antennas
  Dictionary<char, List<(int, int)>> antennas = new Dictionary<char, List<(int, int)>>();

  for (int r = 0; r < rows; r++)
  {
    for (int c = 0; c < cols; c++)
    {
      char ch = grid[r][c];
      if (ch != '.')
      {
        if (!antennas.ContainsKey(ch))
        {
          antennas[ch] = new List<(int, int)>();
        }
        antennas[ch].Add((r, c));
      }
    }
  }

  // Calculate antinodes
  HashSet<(int, int)> antinodes = new HashSet<(int, int)>();

  foreach (var array in antennas.Values)
  {
    for (int i = 0; i < array.Count; i++)
    {
      for (int j = i + 1; j < array.Count; j++)
      {
        (int r1, int c1) = array[i];
        (int r2, int c2) = array[j];

        // Calculate and add antinodes
        antinodes.Add((2 * r1 - r2, 2 * c1 - c2));
        antinodes.Add((2 * r2 - r1, 2 * c2 - c1));
      }
    }
  }

  // Count valid antinodes within grid bounds
  int validCount = antinodes.Count(node =>
      node.Item1 >= 0 && node.Item1 < rows &&
      node.Item2 >= 0 && node.Item2 < cols);

  // Output result
  Console.WriteLine(validCount);
}

void part2()
{
  List<string> grid = File.ReadAllText(@"C:\Users\yvesg\git\aoc2024\08\data.txt")
                              .Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
                              .Select(line => line.Trim())
                              .ToList();

  int rows = grid.Count;
  int cols = grid[0].Length;

  // Store antennas
  var antennas = new Dictionary<char, List<(int, int)>>();

  for (int r = 0; r < rows; r++)
  {
    for (int c = 0; c < cols; c++)
    {
      char ch = grid[r][c];
      if (ch != '.')
      {
        if (!antennas.ContainsKey(ch))
        {
          antennas[ch] = new List<(int, int)>();
        }
        antennas[ch].Add((r, c));
      }
    }
  }

  // Set to store antinodes
  var antinodes = new HashSet<(int, int)>();

  // Calculate antinodes
  foreach (var array in antennas.Values)
  {
    for (int i = 0; i < array.Count; i++)
    {
      for (int j = 0; j < array.Count; j++)
      {
        if (i == j) continue;

        (int r1, int c1) = array[i];
        (int r2, int c2) = array[j];
        int dr = r2 - r1;
        int dc = c2 - c1;
        int r = r1;
        int c = c1;

        while (r >= 0 && r < rows && c >= 0 && c < cols)
        {
          antinodes.Add((r, c));
          r += dr;
          c += dc;
        }
      }
    }
  }

  // Output the number of unique antinodes
  Console.WriteLine(antinodes.Count);
}

part1();
part2();
