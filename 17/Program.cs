using System.Text.RegularExpressions;

string input = @"C:\Users\yvesg\git\aoc2024\17\test.txt";
if (args.Length > 0)
{
  input = args[0];
}

string pattern = @"\d+";
Regex re = new Regex(pattern);
MatchCollection matches = re.Matches(File.ReadAllText(input).ToString());
int a = int.Parse(matches[0].Value);
int b = int.Parse(matches[1].Value);
int c = int.Parse(matches[2].Value);

List<int> op = [];
for (int i = 3; i < matches.Count;i++) {
  op.Add(int.Parse(matches[i].Value));
}

void part1() {

}

void part2() {

}

part1();

part2();