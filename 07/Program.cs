using System.IO.Pipelines;

int calc(int sum, List<int>nums) {
  int result = 0;
  for (int plus = 0; plus < nums.Count; plus++) {

  }
  return result;
}

void part1() {
  StreamReader sr = new StreamReader(@"C:\Users\yvesg\git\aoc2024\07\test.txt");
  while (!sr.EndOfStream) {
    string? line = sr.ReadLine();
    string[] split = line.Split(':');
    int sum = int.Parse(split[0]);
    List<int> nums = split[1]?.Split(' ')?.Select(Int32.Parse)?.ToList();
    
  }
} 

part1();