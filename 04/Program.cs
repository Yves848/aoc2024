void part1()
{
  StreamReader sr = new StreamReader("data.txt");
  string[] text = sr.ReadToEnd().Split("\r\n");
  int l = text[0].Length;
  int h = text.Length;
  Console.WriteLine($"l: {l}, h: {h}");
  List<string> grid = new List<string>();
  grid.Add("".PadLeft(l + 6, '#'));
  grid.Add("".PadLeft(l + 6, '#'));
  grid.Add("".PadLeft(l + 6, '#'));



  for (int i = 0; i < text.Length; i++)
  {
    grid.Add("###" + text[i].PadRight(l, ' ') + "###");
  }
  grid.Add("".PadLeft(l + 6, '#'));
  grid.Add("".PadLeft(l + 6, '#'));
  grid.Add("".PadLeft(l + 6, '#'));

  for (int i = 0; i < grid.Count; i++)
  {
    Console.WriteLine(grid[i]);
  }

  int x = 3, y = 3;
int count = 0;
  for (int yy = y; yy < h + 3; yy++)
  {
    for (int xx = x; xx < l + 3; xx++)
    {
      char c = grid[yy][xx];
      string word = "";
      if (c == 'X')
      {
        // LEFT
        for (int i = 0; i < 4; i++)
        {
          word += grid[yy][xx - i];
        }
        if (word == "XMAS")
        {
          Console.WriteLine("LEFT");
          count++;
        }
        // RIGHT
        word = "";
        for (int i = 0; i < 4; i++)
        {
          word += grid[yy][xx + i];
        }
        if (word == "XMAS")
        {
          Console.WriteLine("RIGHT");
          count++;
        }
        // UP
        word = "";
        for (int i = 0; i < 4; i++)
        {
          word += grid[yy - i][xx];
        }
        if (word == "XMAS")
        {
          Console.WriteLine("UP");
          count++;
        }
        // DOWN
        word = "";
        for (int i = 0; i < 4; i++)
        {
          word += grid[yy + i][xx];
        }
        if (word == "XMAS")
        {
          Console.WriteLine("DOWN");
          count++;
        }
        // UPLEFT
        word = "";
        for (int i = 0; i < 4; i++)
        {
          word += grid[yy - i][xx - i];
        }
        if (word == "XMAS")
        {
          Console.WriteLine("UPLEFT");
          count++;
        }
        // UPRIGHT
        word = "";
        for (int i = 0; i < 4; i++)
        {
          word += grid[yy - i][xx + i];
        }
        if (word == "XMAS")
        {
          Console.WriteLine("UPRIGHT");
          count++;
        }
        // DOWNLEFT
        word = "";
        for (int i = 0; i < 4; i++)
        {
          word += grid[yy + i][xx - i];
        }
        if (word == "XMAS")
        {
          Console.WriteLine("DOWNLEFT");
          count++;
        }
        // DOWNRIGHT
        word = "";
        for (int i = 0; i < 4; i++)
        {
          word += grid[yy + i][xx + i];
        }
        if (word == "XMAS")
        {
          Console.WriteLine("DOWNRIGHT");
          count++;
        }
      }
    }
    // Console.Write("\n");
  }
  Console.WriteLine(count);



  sr.Close();
}

void part2()
{
  StreamReader sr = new StreamReader("data.txt");
  string[] text = sr.ReadToEnd().Split("\r\n");
  int l = text[0].Length;
  int h = text.Length;
  Console.WriteLine($"l: {l}, h: {h}");
  List<string> grid = new List<string>();
  grid.Add("".PadLeft(l + 6, '#'));
  grid.Add("".PadLeft(l + 6, '#'));
  grid.Add("".PadLeft(l + 6, '#'));



  for (int i = 0; i < text.Length; i++)
  {
    grid.Add("###" + text[i].PadRight(l, ' ') + "###");
  }
  grid.Add("".PadLeft(l + 6, '#'));
  grid.Add("".PadLeft(l + 6, '#'));
  grid.Add("".PadLeft(l + 6, '#'));

  for (int i = 0; i < grid.Count; i++)
  {
    Console.WriteLine(grid[i]);
  }

  int x = 3, y = 3;
int count = 0;
  for (int yy = y; yy < h + 3; yy++)
  {
    for (int xx = x; xx < l + 3; xx++)
    {
      char c = grid[yy][xx];
      string word = "";
      if (c == 'A')
      {
        string word1 = (grid[yy-1][xx-1]).ToString()+(grid[yy][xx]).ToString()+(grid[yy+1][xx+1]).ToString();
        string word2 = (grid[yy+1][xx-1]).ToString()+(grid[yy][xx]).ToString()+(grid[yy-1][xx+1]).ToString();
        if ((word1 == "MAS" || word1 == "SAM") && (word2 == "SAM" || word2 == "MAS")) count++;


      }
    }
    // Console.Write("\n");
  }
  Console.WriteLine(count);
  sr.Close();
}


// part1();
part2();
