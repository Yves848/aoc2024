StreamReader sr = new StreamReader("data.txt");


List<Int32> left = new List<Int32>();
List<Int32> right = new List<Int32>();

while (!sr.EndOfStream) {
    string? line = sr.ReadLine().Replace("   ",",");
    if (line == null || line == "") continue;
    var parts = line.Split(',');
    left.Add(Convert.ToInt32(parts[0].Trim()));
    right.Add(Convert.ToInt32(parts[1].Trim()));
}
sr.Close();
left.Sort();
right.Sort();

Int32 i = 0;
Int32 total = 0;
while (i < left.Count) {
    List<Int32> nb = right.FindAll(x => x == left[i]);
    total += (left[i]*nb.Count);
    i++;
}

Console.WriteLine("Total: " + total);