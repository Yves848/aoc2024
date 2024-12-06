
void part1() {
  StreamReader sr = new StreamReader(@"C:\Users\yvesg\git\aoc2024\06\data.txt");
  List<string> grid = new List<string>();
  int x=0 , y = 0;
  while(!sr.EndOfStream) {
    string line = sr.ReadLine();
    if (line.IndexOf('^') > -1) {
      x = line.IndexOf('^');
      y = grid.Count();
    } 
    grid.Add(line);
  }
  (int,int)[] directions = [(-1,0),(0,1),(1,0),(0,-1)];
  int d = 0; // UP;
  int count = 1;
  while(true) {
    if ((y + directions[d].Item1) < 0 || (y + directions[d].Item1) >= grid.Count()  ) break;
    if ((x + directions[d].Item2) < 0 || (x + directions[d].Item2) >= grid[0].Length  ) break;
    y += directions[d].Item1;
    x += directions[d].Item2;
    if (grid[y][x] == '#') {
      y -= directions[d].Item1;
      x -= directions[d].Item2;
      d++;
      if (d>= directions.Length) {d = 0;}
    } else {
      if (grid[y][x] != 'X') count ++;
      grid[y] = grid[y].Remove(x,1).Insert(x,"X");
    }
  }
  Console.WriteLine($"Count : {count}");
}

part1();